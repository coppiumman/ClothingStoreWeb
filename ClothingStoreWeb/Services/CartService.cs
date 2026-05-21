using ClothingStoreWeb.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace ClothingStoreWeb.Services;

public class CartService
{
    private readonly IJSRuntime jsRuntime;
    private readonly AuthenticationStateProvider authenticationStateProvider;
    private readonly List<CartItem> items = [];

    private const string StorageKeyPrefix = "clothingStoreCart_";

    public event Action? OnChange;

    public CartService(
        IJSRuntime jsRuntime,
        AuthenticationStateProvider authenticationStateProvider)
    {
        this.jsRuntime = jsRuntime;
        this.authenticationStateProvider = authenticationStateProvider;
    }

    public IReadOnlyList<CartItem> Items => items;

    public async Task LoadCartAsync()
    {
        try
        {
            var storageKey = await GetStorageKeyAsync();

            var savedItems = await jsRuntime.InvokeAsync<List<CartItem>?>(
                "cartStorage.load",
                storageKey);

            items.Clear();

            if (savedItems is not null)
            {
                items.AddRange(savedItems);
            }

            NotifyStateChanged();
        }
        catch (InvalidOperationException)
        {
        }
    }

    private async Task SaveCartAsync()
    {
        try
        {
            var storageKey = await GetStorageKeyAsync();

            await jsRuntime.InvokeVoidAsync(
                "cartStorage.save",
                storageKey,
                items);
        }
        catch (InvalidOperationException)
        {
        }
    }

    public async Task AddItemAsync(CartItem item)
    {
        var existingItem = items.FirstOrDefault(x =>
            x.Product_Id == item.Product_Id &&
            x.Size_Id == item.Size_Id);

        if (existingItem is not null)
        {
            existingItem.Quantity = Math.Min(
                existingItem.Quantity + item.Quantity,
                existingItem.AvailableQuantity
            );
        }
        else
        {
            item.Quantity = Math.Min(item.Quantity, item.AvailableQuantity);
            items.Add(item);
        }

        await SaveCartAsync();
        NotifyStateChanged();
    }

    public async Task RemoveItemAsync(int productId, int sizeId)
    {
        var item = items.FirstOrDefault(x =>
            x.Product_Id == productId &&
            x.Size_Id == sizeId);

        if (item is not null)
        {
            items.Remove(item);
            await SaveCartAsync();
            NotifyStateChanged();
        }
    }

    public async Task IncreaseQuantityAsync(int productId, int sizeId)
    {
        var item = items.FirstOrDefault(x =>
            x.Product_Id == productId &&
            x.Size_Id == sizeId);

        if (item is not null && item.Quantity < item.AvailableQuantity)
        {
            item.Quantity++;
            await SaveCartAsync();
            NotifyStateChanged();
        }
    }

    public async Task DecreaseQuantityAsync(int productId, int sizeId)
    {
        var item = items.FirstOrDefault(x =>
            x.Product_Id == productId &&
            x.Size_Id == sizeId);

        if (item is null)
        {
            return;
        }

        item.Quantity--;

        if (item.Quantity <= 0)
        {
            items.Remove(item);
        }

        await SaveCartAsync();
        NotifyStateChanged();
    }

    public async Task ClearAsync()
    {
        items.Clear();

        try
        {
            var storageKey = await GetStorageKeyAsync();

            await jsRuntime.InvokeVoidAsync(
                "cartStorage.remove",
                storageKey);
        }
        catch (InvalidOperationException)
        {
        }

        NotifyStateChanged();
    }

    public decimal GetTotalPrice()
    {
        return items.Sum(x => x.TotalPrice);
    }

    public int GetTotalQuantity()
    {
        return items.Sum(x => x.Quantity);
    }

    private async Task<string> GetStorageKeyAsync()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrWhiteSpace(userId))
            {
                return StorageKeyPrefix + userId;
            }
        }

        return StorageKeyPrefix + "anonymous";
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}