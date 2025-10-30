# WPFApp

A simple WPF application using Entity Framework Core and SQLite to import, display, and manage documents and their items from CSV files.

---

## Project Description

This desktop application allows the user to:

- Import two types of CSV files:
  - **Documents.csv** – contains document metadata  
  - **DocumentItems.csv** – contains items related to those documents  
- View all documents in a read-only **DataGrid**
- Double-click a document to view its items in a separate window
- Filter documents using a search bar

The project uses a local **SQLite** database (`Database.db`) and **Entity Framework Core** as the ORM.

---

## Developer Environment Setup

### 1. Prerequisites

- .NET 8 SDK
- Visual Studio 2022
- Installed NuGet packages:
  ```bash
  Microsoft.EntityFrameworkCore
  Microsoft.EntityFrameworkCore.Sqlite
  Microsoft.Data.Sqlite

### Step 2. Setup (Developer Environment)

Follow these steps to prepare and run the project locally:

1. **Restore dependencies**
   ```bash
   dotnet restore
2. **Build the project**
   ```bash
    dotnet build
3. **Run the application**
    ```bash
    dotnet run
    
---

### Notes

  Documents must be imported before document items.

### CSV Format
  **Documents.csv**
  ```bash
  Id;Type;Date;FirstName;LastName;City
  1;Invoice;2025-10-01;John;Doe;New York
  ```
  **DocumentItems.csv**
  ```bash
  DocumentId;Ordinal;Product;Quantity;Price;TaxRate
  1;1;Laptop;2;1000;1
  ```
