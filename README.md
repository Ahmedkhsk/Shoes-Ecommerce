
# 👟 Shoes Ecommerce API

This is a RESTful API built with **ASP.NET Core** for managing an e-commerce platform focused on selling shoes.  
It handles user management, products, cart operations, favorites, notifications, and more.

---

## 🚀 Features

### ✅ Authentication & Authorization
- Register and login with JWT-based auth
- Role-based access for users and admins

### 🛍️ Products
- Add / Edit / Delete products
- Fetch all products or by category

### 🧺 Cart
- Add to cart, update quantity, remove items
- Get user cart

### ❤️ Favorites
- Add/remove product to favorites
- Fetch all favorite items for a user

### 🔔 Notifications
- Notify users when new products are added
- Integrated with **Firebase Cloud Messaging (FCM)**

### 📂 Categories
- Organize products by category
- Fetch products under each category

---

## 🧰 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Firebase Cloud Messaging (FCM)

---

## ⚙️ Getting Started

1. **Clone the repo**
```bash
git clone https://github.com/Ahmedkhsk/Shoes-Ecommerce.git
cd Shoes-Ecommerce
```

2. **Update `appsettings.json`**  
   Add your DB connection string and FCM credentials.

3. **Run migrations**
```bash
dotnet ef database update
```

4. **Run the project**
```bash
dotnet run
```

---

## 📫 Contact

Built with ❤️ by [Ahmed Khaled](https://github.com/Ahmedkhsk)  
For inquiries or contributions, feel free to reach out or open an issue.

