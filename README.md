# ClothingStoreWeb

Интернет-магазин одежды — full-stack веб-приложение на **ASP.NET Core 9.0 / Blazor Server** с витриной для покупателей и полноценной админ-панелью для сотрудников.

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?logo=blazor&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-9.0-512BD4)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=white)

> 🇷🇺 Русская версия — ниже. 🇬🇧 [English version](#-english).

---

## 🇷🇺 Описание

**ClothingStoreWeb** — это полнофункциональная платформа интернет-магазина одежды. Покупатели просматривают каталог, наполняют корзину и оформляют заказы; сотрудники управляют товарами, складом, заказами и контентом через защищённую админ-панель с разграничением прав по должностям. Интерфейс полностью на русском языке.

## Возможности

### Для покупателей
- 🛍️ **Каталог** товаров с фильтрацией по категориям/цвету и сортировкой по цене
- 👕 **Карточка товара** с несколькими изображениями и выбором размера
- 🛒 **Корзина** с сохранением между сессиями (browser `localStorage` через JS interop)
- 💳 **Оформление заказа**: получатель, телефон, способы доставки (самовывоз / курьер / ПВЗ) и оплаты, согласие на обработку ПД, проверка остатков на складе
- 👤 **Личный кабинет**: текущие заказы, история, отмена заказа, управление данными
- ℹ️ Информационные страницы: доставка, оплата, возврат, помощь

### Для администраторов и сотрудников
- 🗂️ **CRUD** по категориям, товарам, размерам, складу, заказам, сотрудникам и баннерам
- 📦 **Управление складом** по комбинации «товар + размер»
- 📊 **Отчёты и аналитика** на Plotly: выручка по месяцам, топ товаров, заказы по статусам, низкие остатки
- 📥 **Импорт/экспорт товаров в Excel** (ClosedXML) с контролем доступа
- 🙈 **Скрытие** товаров и категорий (видны только сотрудникам), защита прямых ссылок

## Технологический стек

| Слой | Технология |
|------|-----------|
| Бэкенд | ASP.NET Core 9.0 |
| UI | Blazor Server (Interactive Server Components), ~104 `.razor`-компонента |
| ORM | Entity Framework Core 9.0.15 (code-first + миграции) |
| База данных | SQL Server |
| Аутентификация | ASP.NET Core Identity (ролевая модель) |
| Таблицы данных | Microsoft QuickGrid + EF Core Adapter |
| Графики | Plotly.Blazor 7.1.0 |
| Excel | ClosedXML 0.105.0 |
| Стили | Bootstrap + scoped CSS |
| CI/CD | GitHub Actions |

## Архитектура

Слоистая архитектура, адаптированная под компонентную модель Blazor:

- **Presentation** — Razor-компоненты с серверным интерактивным рендерингом; два лейаута: `PublicLayout` (витрина) и `MainLayout` (админка)
- **Business Logic** — `CartService` (корзина + `localStorage`) и `EmployeeAccessService` (контроль доступа сотрудников)
- **Data Access** — `ApplicationDbContext` (EF Core), сидинг через `SeedData`

```
ClothingStoreWeb/
├── Components/
│   ├── Pages/          # Страницы: PublicPages (витрина), CRUD-разделы, Reports
│   ├── Layout/         # MainLayout, PublicLayout, NavMenu
│   └── Account/        # Страницы ASP.NET Core Identity
├── Models/             # 9 доменных сущностей
├── Data/               # ApplicationDbContext, ApplicationUser, SeedData, Migrations
├── Services/           # CartService, EmployeeAccessService
├── wwwroot/            # CSS, JS, Bootstrap, изображения
├── Program.cs          # Конфигурация, DI, middleware
└── appsettings.json    # Строка подключения, логирование
```

## Доменная модель

`Category` → `Product` → `Stock` ← `Size` · `Order` → `OrderItem` · `Employee` · `HomeBanner` · `ApplicationUser`

- **Category / Product / Size** — каталог; `Stock` хранит остатки по паре «товар + размер» (уникальный индекс)
- **Order / OrderItem** — заказы и их позиции (товар, размер, количество, цена)
- **Employee** — сотрудник, привязан к `ApplicationUser`
- **HomeBanner** — баннеры на главной
- **CartItem** — позиция корзины (в браузере, не в БД)

## Роли и доступ

| Роль | Права |
|------|-------|
| **Администратор** | Полный доступ ко всем разделам |
| **Сотрудник** | Доступ зависит от должности (ниже) |
| **Пользователь** | Только публичные страницы |

Должности сотрудников: **Менеджер** (создание/редактирование без удаления), **Кладовщик** (только склад), **Консультант** (только просмотр). Тонкая проверка прав — в `EmployeeAccessService`.

## Запуск

**Требования:** [.NET 9 SDK](https://dotnet.microsoft.com/download), SQL Server (LocalDB или полноценный экземпляр).

1. Настройте строку подключения в `ClothingStoreWeb/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=ClothingStoreDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
   }
   ```
2. Подготовьте базу данных одним из способов:
   - восстановите из бэкапа `ClothingStoreDb11.bak`, **или**
   - примените миграции: `dotnet ef database update` (база также наполняется через `SeedData` при старте).
3. Запустите приложение:
   ```bash
   dotnet run --project ClothingStoreWeb
   ```
4. Откройте:
   - HTTPS: `https://localhost:7155`
   - HTTP: `http://localhost:5247`

## CI/CD

Сборка настроена в GitHub Actions — `.github/workflows/dotnet.yml` (restore → build → test) при push и pull request в `master`.

---

## 🇬🇧 English

**ClothingStoreWeb** is a full-featured clothing-store e-commerce platform. Customers browse the catalog, fill a cart and place orders; staff manage products, stock, orders and content through a secured admin panel with role- and position-based permissions. The UI is in Russian.

### Features

**Customer-facing**
- 🛍️ Product **catalog** with category/color filtering and price sorting
- 👕 **Product page** with multiple images and size selection
- 🛒 **Cart** persisted across sessions (browser `localStorage` via JS interop)
- 💳 **Checkout**: recipient, phone, delivery methods (pickup / courier / pickup point) and payment, consent, stock validation
- 👤 **Profile**: current orders, history, cancellation, account management
- ℹ️ Info pages: delivery, payment, returns, help

**Admin / staff**
- 🗂️ **CRUD** for categories, products, sizes, stock, orders, employees and banners
- 📦 **Inventory** tracked per «product + size» pair
- 📊 **Reports & analytics** with Plotly: monthly revenue, top products, orders by status, low stock
- 📥 **Excel import/export** of products (ClosedXML) with access control
- 🙈 **Hide** products/categories (staff-only), with protected direct links

### Tech stack

| Layer | Technology |
|-------|-----------|
| Backend | ASP.NET Core 9.0 |
| UI | Blazor Server (Interactive Server Components) |
| ORM | Entity Framework Core 9.0.15 (code-first + migrations) |
| Database | SQL Server |
| Auth | ASP.NET Core Identity (role-based) |
| Data grids | Microsoft QuickGrid + EF Core Adapter |
| Charts | Plotly.Blazor 7.1.0 |
| Excel | ClosedXML 0.105.0 |
| Styling | Bootstrap + scoped CSS |
| CI/CD | GitHub Actions |

### Architecture

Layered architecture adapted to Blazor's component model: **Presentation** (Razor components, `PublicLayout` / `MainLayout`), **Business Logic** (`CartService`, `EmployeeAccessService`), **Data Access** (`ApplicationDbContext` with EF Core, seeded via `SeedData`).

### Roles

- **Administrator** — full access to all sections
- **Employee** — access depends on position: *Manager* (create/edit, no delete), *Storekeeper* (stock only), *Consultant* (read-only)
- **User** — public pages only

### Getting started

**Prerequisites:** .NET 9 SDK, SQL Server.

1. Set the connection string in `ClothingStoreWeb/appsettings.json`.
2. Prepare the database: restore `ClothingStoreDb11.bak` **or** run `dotnet ef database update` (data is also seeded on startup via `SeedData`).
3. Run: `dotnet run --project ClothingStoreWeb`.
4. Open `https://localhost:7155` or `http://localhost:5247`.

### CI/CD

Builds run via GitHub Actions — `.github/workflows/dotnet.yml` (restore → build → test) on push and pull requests to `master`.
