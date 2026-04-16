# Eshal.Blazor

A Blazor solution that demonstrates reusable UI components and dynamic UI patterns.

## Projects in this repository

- `MessageModel` (`net8.0`)  
  Reusable inline message component with success/failure/alert/warning styles.
- `ToastNotification` (`net8.0`)  
  Reusable toast component controlled directly by parent state.
- `ToastNotificationService` (`net8.0`)  
  Toast system driven by a shared `ToastService` (recommended when multiple pages trigger notifications).
- `EditableDynamicTable` (`net9.0`)  
  Dynamic table that supports add/remove/rename columns, add/remove rows, and Excel upload.

---

## Reusable components

## 1) MessageModel component

**File:** `MessageModel/MessageModel/Components/Shared/MessageModel.razor`

### What it does
- Displays a styled message box.
- Supports message types: `success`, `failure`, `alert`, `warning`.
- Can be shown/hidden with a `bool` from the parent.

### How to use
1. Import or reference the component namespace (for example in `_Imports.razor` or with `@using` in the page).
2. Add the component to your page.
3. Bind `ShowMessage` to parent state and toggle that state from button/event handlers.

### Example usage
Use the implementation in:  
`MessageModel/MessageModel/Components/Pages/Home.razor`

---

## 2) ToastNotification component (direct state-based)

**File:** `ToastNotification/Components/Shared/ToastNotification.razor`

### What it does
- Shows toast notifications with close support and auto-dismiss (`DismissAfter` in seconds).
- Supports message types: `success`, `failure`, `alert`, `warning`.
- Uses `ShowMessageChanged` callback so parent state is updated when toast closes.

### How to use
1. Add `<ToastNotification ... />` in your page.
2. Pass `MessageContent`, `MessageType`, and `ShowMessage`.
3. Pass `ShowMessageChanged` callback to sync visibility state back to parent.
4. Set `DismissAfter` if you want automatic close.

### Example usage
Use the implementation in:  
`ToastNotification/Components/Pages/Home.razor`

---

## 3) ToastNotificationService component (service-based)

**Files:**  
- `ToastNotificationService/ToastMessage/ToastService.cs`  
- `ToastNotificationService/Components/Shared/Toast.razor`

### What it does
- Centralized toast handling through DI service.
- Any page/component can trigger toast messages without managing toast UI state directly.

### How to implement
1. **Register service** in `Program.cs`:
   - `builder.Services.AddSingleton<ToastService>();`
2. **Place toast host component** once in layout (already done in `Components/Layout/MainLayout.razor` using `<Toast />`).
3. **Inject service** where needed:
   - `@inject ToastService ToastService`
4. **Trigger notifications** from actions:
   - `ToastService.ShowSuccess(...)`
   - `ToastService.ShowError(...)`
   - `ToastService.ShowWarning(...)`
   - `ToastService.ShowAlert(...)`
   - `ToastService.ShowInfo(...)`

### Example usage
Use the implementation in:  
`ToastNotificationService/Components/Pages/Home.razor`

---

## 4) EditableDynamicTable (dynamic component/page)

**File:** `EditableDynamicTable/Components/Pages/ExcelTable.razor`

### What it does
- Dynamic column and row management.
- Inline cell editing.
- Excel file upload support (via `EPPlus` package).

### How to use
1. Run the `EditableDynamicTable` project.
2. Open `/excel-table`.
3. Use:
   - **Add Column** to create new columns.
   - **Add Row** to add editable rows.
   - **Remove** buttons to delete rows/columns.
   - File upload to load data from Excel.

---

## Run the projects

From repository root:

- MessageModel  
  `dotnet run --project /home/runner/work/Eshal.Blazor/Eshal.Blazor/MessageModel/MessageModel/MessageModel.csproj`
- ToastNotification  
  `dotnet run --project /home/runner/work/Eshal.Blazor/Eshal.Blazor/ToastNotification/ToastNotification.csproj`
- ToastNotificationService  
  `dotnet run --project /home/runner/work/Eshal.Blazor/Eshal.Blazor/ToastNotificationService/ToastNotificationService.csproj`
- EditableDynamicTable  
  `dotnet run --project /home/runner/work/Eshal.Blazor/Eshal.Blazor/EditableDynamicTable/EditableDynamicTable.csproj`

---

## Build

```bash
dotnet build /home/runner/work/Eshal.Blazor/Eshal.Blazor/Eshal.Blazor.sln
```
