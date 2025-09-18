🍔 Meal-Prepped

A web store application where users can browse food items, add them to a cart, and place orders. The application is built with ASP.NET Core and Entity Framework Core.

⚡ Setup Instructions

This project requires a compiler (such as Visual Studio) to run. Since the application uses Entity Framework Core, it does not come with a pre-attached database.

After cloning the repository and opening the project, you must run the following command in the NuGet Package Manager Console:

update-database

This will create and configure the database for the application.

Note: If using visual studio, you can access the NuGet Package Manager Console easily by selecting Tools > NuGet Package Manager > Package Manager Console.
<img width="1109" height="438" alt="image" src="https://github.com/user-attachments/assets/d6a8339f-4ef2-4d33-b51a-b8649e492b4c" />


🔑 Creating an Admin Account

To access the CRUD pages for managing products in the database, you will need an Admin account.

By default, new accounts are registered as User. To set up an Admin account during registration:

Open the file:
Areas/Identity/Pages/Account/Register.cshtml.cs
<img width="292" height="575" alt="image" src="https://github.com/user-attachments/assets/ca51ca78-24b8-45fd-8a7f-ef03108cb09f" />

Locate the following section on line 132:

//await _userManager.AddToRoleAsync(user, "Admin"); // TEMPORARY
await _userManager.AddToRoleAsync(user, "User");   // after initial setup
<img width="1082" height="890" alt="image" src="https://github.com/user-attachments/assets/092a2153-1f3d-4cbc-aa8d-a95b9800ffed" />

Swap the commented line so that Admin is enabled instead of User.

After creating the Admin account, switch it back to User to avoid granting Admin rights to future registrations.


✨ Features

🛒 Cart System – Add, remove, and update items before checkout

👤 User Authentication – Register and log in securely

🔑 Role-Based Access – Admins can manage products, while users can place orders

📦 CRUD Operations – Admin can create, read, update, and delete products

📊 Entity Framework Core Integration – Database migrations and seeding

🎨 Responsive Design – Built with Bootstrap for mobile and desktop compatibility

🛠️ Tech Stack

ASP.NET Core – Backend framework

Entity Framework Core – ORM for database management

SQL Server – Database engine

Bootstrap – Frontend styling and layout

C# – Primary programming language


📸 Application Preview

Below are screenshots of the application running with a fully functional database (cart system, product listings, and admin pages).

<img width="1916" height="908" alt="image" src="https://github.com/user-attachments/assets/978b5911-681e-4e74-97c8-dcc31d3fa41e" />
<img width="1916" height="908" alt="image" src="https://github.com/user-attachments/assets/dcea21dd-0c3d-4bc7-b950-6861c5ab9cda" />
<img width="1917" height="861" alt="image" src="https://github.com/user-attachments/assets/56f6677b-b60f-44c6-b694-0d4d7b59d390" />
<img width="2556" height="1266" alt="image" src="https://github.com/user-attachments/assets/94d383f0-d322-4cfc-9071-70a7399c0edb" />
<img width="2554" height="1268" alt="image" src="https://github.com/user-attachments/assets/3788e499-3fa3-4171-a00b-ff35ff849b13" />
<img width="2558" height="1266" alt="image" src="https://github.com/user-attachments/assets/9dd8d45e-2503-4265-8ddf-7e038bf97a7f" />
<img width="2557" height="1268" alt="image" src="https://github.com/user-attachments/assets/a9954394-75f6-424b-b0b8-27dac7f1dd4b" />
<img width="2558" height="1267" alt="image" src="https://github.com/user-attachments/assets/a9f79b6b-bb5d-4afe-9b8b-36d7469109d0" />
