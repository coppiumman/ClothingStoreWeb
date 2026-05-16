using ClothingStoreWeb.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ClothingStoreWeb.Services;

public class EmployeeAccessService(
    AuthenticationStateProvider authenticationStateProvider,
    IDbContextFactory<ApplicationDbContext> dbFactory)
{
    private const string AdminRoleName = "Администратор";
    private const string ManagerPosition = "Менеджер";
    private const string StorekeeperPosition = "Кладовщик";
    private const string ConsultantPosition = "Консультант";

    private static readonly HashSet<string> ServiceSections =
    [
        "Categories",
        "Products",
        "Sizes",
        "Stocks",
        "Orders",
        "OrderItems"
    ];

    private static readonly HashSet<string> StorekeeperManageSections =
    [
        "Products",
        "Sizes",
        "Stocks"
    ];

    public async Task<bool> IsAdminAsync()
    {
        var principal = await GetCurrentPrincipalAsync();
        return principal?.IsInRole(AdminRoleName) == true;
    }

    public async Task<string?> GetEmployeePositionAsync()
    {
        var principal = await GetCurrentPrincipalAsync();
        var userId = principal?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
        {
            return null;
        }

        await using var context = await dbFactory.CreateDbContextAsync();
        return await context.Employees
            .AsNoTracking()
            .Where(employee => employee.User_Id == userId)
            .Select(employee => employee.Employee_Position)
            .FirstOrDefaultAsync();
    }

    public Task<bool> CanViewAsync(string section) => CanAccessAsync(section, EmployeeAction.View);

    public Task<bool> CanCreateAsync(string section) => CanAccessAsync(section, EmployeeAction.Create);

    public Task<bool> CanEditAsync(string section) => CanAccessAsync(section, EmployeeAction.Edit);

    public Task<bool> CanDeleteAsync(string section) => CanAccessAsync(section, EmployeeAction.Delete);

    public async Task<bool> CanManageAsync(string section)
    {
        return await CanCreateAsync(section)
            && await CanEditAsync(section)
            && await CanDeleteAsync(section);
    }

    private async Task<bool> CanAccessAsync(string section, EmployeeAction action)
    {
        var principal = await GetCurrentPrincipalAsync();
        if (principal is null)
        {
            return false;
        }

        if (principal.IsInRole(AdminRoleName))
        {
            return true;
        }

        if (!ServiceSections.Contains(section))
        {
            return false;
        }

        var position = await GetEmployeePositionAsync(principal);
        return position switch
        {
            ManagerPosition => true,
            StorekeeperPosition => action == EmployeeAction.View || StorekeeperManageSections.Contains(section),
            ConsultantPosition => action == EmployeeAction.View,
            _ => false
        };
    }

    private async Task<string?> GetEmployeePositionAsync(ClaimsPrincipal principal)
    {
        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
        {
            return null;
        }

        await using var context = await dbFactory.CreateDbContextAsync();
        return await context.Employees
            .AsNoTracking()
            .Where(employee => employee.User_Id == userId)
            .Select(employee => employee.Employee_Position)
            .FirstOrDefaultAsync();
    }

    private async Task<ClaimsPrincipal?> GetCurrentPrincipalAsync()
    {
        var authenticationState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var principal = authenticationState.User;

        if (principal.Identity?.IsAuthenticated != true)
        {
            return null;
        }

        return principal;
    }

    private enum EmployeeAction
    {
        View,
        Create,
        Edit,
        Delete
    }
}
