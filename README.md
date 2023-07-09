# Whammy Web

Whammy Web is a full-stack ASP.NET Core web application designed to provide a comprehensive e-commerce platform. This application offers various features, including authentication, authorization, payment handling with Stripe, and support for multiple user roles. Whether you're a customer, an administrator, or a seller, Whammy Web ensures a seamless and secure shopping experience.

Whammy Web follows industry best practices, incorporating the Unit of Work pattern and N-tier architecture. The application leverages the Unit of Work pattern to provide a consistent and efficient way to manage database transactions and ensure data integrity. The N-tier architecture separates the application into distinct layers, including presentation, business logic, and data access. This architecture promotes modularity, scalability, and maintainability.


## Features

- **User Authentication**: Whammy Web enables secure user authentication, allowing customers and sellers to create and manage their accounts easily. This ensures that each user's data and transactions are protected.

- **User Authorization**: With Whammy Web, you can define multiple user roles and assign specific privileges to each role. This granular level of authorization ensures that only authorized users can access sensitive functionalities and data.

- **Product Catalog**: The application provides an extensive product catalog, showcasing a wide range of products available for purchase. Users can browse through categories, view product details, and add items to their shopping cart.

- **Shopping Cart**: Whammy Web includes a robust shopping cart system that allows users to add and remove items, update quantities, and save items for later. This feature ensures a smooth and intuitive shopping experience.

- **Payment Handling with Stripe**: The application integrates with the Stripe payment gateway, enabling secure and reliable payment processing. Users can complete transactions using various payment methods, including credit cards, ensuring a seamless checkout process.

- **Order Management**: Whammy Web includes an intuitive order management system for both customers and sellers. Customers can view their order history, track shipments, and manage returns, while sellers can manage inventory, process orders, and update order statuses.

- **User Roles**: Whammy Web supports different user roles, including customers, administrators, and sellers. Each role has specific functionalities and permissions, ensuring appropriate access and management capabilities for different user types.

## Best Practices

Whammy Web follows industry best practices, including:

- **Unit of Work Pattern**: The application leverages the Unit of Work pattern, which provides a consistent and efficient way to manage database transactions and ensure data integrity.

- **N-tier Architecture**: Whammy Web adopts the N-tier architecture, separating the application into distinct layers such as presentation, business logic, and data access. This architecture promotes modularity, scalability, and maintainability.

By incorporating these best practices, Whammy Web aims to provide a robust and well-structured codebase that is scalable, maintainable, and adheres to industry standards.

## Installation and Setup

To get started with Whammy Web, follow these steps:

1. Clone the repository: `git clone https://github.com/mohiden/WhammpyWeb.git`
2. Navigate to the project directory: `cd whammyWeb`
3. Install the required dependencies: `dotnet restore`
4. Configure the database connection string in the `appsettings.json` file.
5. Apply the database migrations: `dotnet ef database update`
6. Start the application: `dotnet run`

Make sure you have the latest version of .NET Core SDK installed on your machine before proceeding with the installation.

## Technology Stack

Whammy Web is built using the following technologies:

- C#: Primary programming language
- ASP.NET Core: Server-side web framework
- Razor Pages: UI framework for creating dynamic web pages with ASP.NET Core
- Entity Framework Core: Object-relational mapper (ORM) for database access
- SQL Server: Relational database management system
- HTML, CSS, JavaScript: Front-end development
- Bootstrap: Front-end CSS framework for responsive design
- Stripe: Payment gateway integration

## Contributing

We welcome contributions from the community! If you'd like to contribute to Whammy Web, please follow our [contribution guidelines](CONTRIBUTING.md) for more information.

## License

Whammy Web is licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute the code as per the terms of the license.

## Acknowledgements

We would like to express our gratitude to the open-source community for their invaluable contributions and support.

## Contact

- email mohidenjama@gmail.com
- twitter @mobinadam

*Note: Replace `your-username` in the installation instructions with your actual GitHub username.*
