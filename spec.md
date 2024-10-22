# Inventory Manager API Specification

## Project Overview

This is an inventory management API built using C# .NET Minimal API. The API will manage products, categories, suppliers, and inventory transactions. It supports basic CRUD operations for each entity and uses PostgreSQL as the database.

---

## Endpoints

### 1. **Categories**

Manage product categories.

| Method | Endpoint               | Description           | Request Body           | Response Body             |
| ------ | ---------------------- | --------------------- | ---------------------- | ------------------------- |
| GET    | `/api/categories`      | Get all categories    | -                      | `Category[]`              |
| GET    | `/api/categories/{id}` | Get category by ID    | -                      | `Category`                |
| POST   | `/api/categories`      | Create a new category | `{ "name": "string" }` | `Category`                |
| PUT    | `/api/categories/{id}` | Update a category     | `{ "name": "string" }` | `Category`                |
| DELETE | `/api/categories/{id}` | Delete a category     | -                      | `{ "message": "string" }` |

### 2. **Products**

Manage products in the inventory.

| Method | Endpoint             | Description          | Request Body                                                                                                   | Response Body             |
| ------ | -------------------- | -------------------- | -------------------------------------------------------------------------------------------------------------- | ------------------------- |
| GET    | `/api/products`      | Get all products     | -                                                                                                              | `Product[]`               |
| GET    | `/api/products/{id}` | Get product by ID    | -                                                                                                              | `Product`                 |
| POST   | `/api/products`      | Create a new product | `{ "name": "string", "price": "decimal", "categoryId": "guid", "supplierId": "guid", "stockQuantity": "int" }` | `Product`                 |
| PUT    | `/api/products/{id}` | Update a product     | `{ "name": "string", "price": "decimal", "categoryId": "guid", "supplierId": "guid", "stockQuantity": "int" }` | `Product`                 |
| DELETE | `/api/products/{id}` | Delete a product     | -                                                                                                              | `{ "message": "string" }` |

### 3. **Suppliers**

Manage suppliers of the products.

| Method | Endpoint              | Description           | Request Body                                    | Response Body             |
| ------ | --------------------- | --------------------- | ----------------------------------------------- | ------------------------- |
| GET    | `/api/suppliers`      | Get all suppliers     | -                                               | `Supplier[]`              |
| GET    | `/api/suppliers/{id}` | Get supplier by ID    | -                                               | `Supplier`                |
| POST   | `/api/suppliers`      | Create a new supplier | `{ "name": "string", "contactInfo": "string" }` | `Supplier`                |
| PUT    | `/api/suppliers/{id}` | Update a supplier     | `{ "name": "string", "contactInfo": "string" }` | `Supplier`                |
| DELETE | `/api/suppliers/{id}` | Delete a supplier     | -                                               | `{ "message": "string" }` |

### 4. **Inventory Transactions**

Manage transactions (stock in/out) for products.

| Method | Endpoint                           | Description                    | Request Body                                                                                           | Response Body             |
| ------ | ---------------------------------- | ------------------------------ | ------------------------------------------------------------------------------------------------------ | ------------------------- |
| GET    | `/api/inventory/transactions`      | Get all inventory transactions | -                                                                                                      | `InventoryTransaction[]`  |
| GET    | `/api/inventory/transactions/{id}` | Get transaction by ID          | -                                                                                                      | `InventoryTransaction`    |
| POST   | `/api/inventory/transactions`      | Record a new transaction       | `{ "productId": "guid", "quantity": "int", "transactionType": "string (IN/OUT)", "date": "DateTime" }` | `InventoryTransaction`    |
| DELETE | `/api/inventory/transactions/{id}` | Delete a transaction           | -                                                                                                      | `{ "message": "string" }` |

---

## Database Models

### 1. **Category**

Represents a product category.

| Field       | Type           | Description            |
| ----------- | -------------- | ---------------------- |
| `Id`        | `UUID`         | Primary key (GUID)     |
| `Name`      | `VARCHAR(100)` | Name of the category   |
| `CreatedAt` | `TIMESTAMP`    | Timestamp when created |

### 2. **Product**

Represents an inventory product.

| Field           | Type            | Description               |
| --------------- | --------------- | ------------------------- |
| `Id`            | `UUID`          | Primary key (GUID)        |
| `Name`          | `VARCHAR(150)`  | Name of the product       |
| `Price`         | `DECIMAL(10,2)` | Price of the product      |
| `CategoryId`    | `UUID`          | Foreign key to `Category` |
| `SupplierId`    | `UUID`          | Foreign key to `Supplier` |
| `StockQuantity` | `INT`           | Current stock quantity    |
| `CreatedAt`     | `TIMESTAMP`     | Timestamp when created    |

### 3. **Supplier**

Represents a supplier for products.

| Field         | Type           | Description                       |
| ------------- | -------------- | --------------------------------- |
| `Id`          | `UUID`         | Primary key (GUID)                |
| `Name`        | `VARCHAR(150)` | Name of the supplier              |
| `ContactInfo` | `VARCHAR(250)` | Contact information (email/phone) |
| `CreatedAt`   | `TIMESTAMP`    | Timestamp when created            |

### 4. **InventoryTransaction**

Represents an inventory transaction (stock in/out).

| Field             | Type          | Description                   |
| ----------------- | ------------- | ----------------------------- |
| `Id`              | `UUID`        | Primary key (GUID)            |
| `ProductId`       | `UUID`        | Foreign key to `Product`      |
| `Quantity`        | `INT`         | Number of items in/out        |
| `TransactionType` | `VARCHAR(10)` | Transaction type (`IN`/`OUT`) |
| `Date`            | `TIMESTAMP`   | Transaction date              |
| `CreatedAt`       | `TIMESTAMP`   | Timestamp when created        |

---

## Response Objects

### Category

```json
{
  "id": "2b2e68e7-8c9b-421b-9f33-5d97c877439f",
  "name": "Electronics",
  "createdAt": "2024-10-22T12:34:56Z"
}
```
