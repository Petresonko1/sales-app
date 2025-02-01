# Sales Application

This is a complete sales application built with a Vue.js frontend and a .NET backend. The application is designed to manage users, products, and orders, with distinct roles for administrators, sales personnel, and customers.

## Project Structure

The project is organized into two main directories: `frontend` and `backend`.

### Frontend

The frontend is built using Vue.js and includes the following components and views:

- **Components**
  - `AdminView.vue`: Allows administrators to manage users and products.
  - `SalesPersonView.vue`: Enables sales personnel to collect orders.
  - `CustomerView.vue`: Allows customers to browse products and place orders.

- **Views**
  - `Admin.vue`: Main view for the Admin interface.
  - `SalesPerson.vue`: Main view for the Sales Person interface.
  - `Customer.vue`: Main view for the Customer interface.

- **Main Files**
  - `App.vue`: Root component of the Vue application.
  - `main.js`: Entry point for the Vue application.
  - `router.js`: Defines the routes for the application.

### Backend

The backend is built using .NET and is structured into several microservices, each responsible for a specific domain:

- **AuthenticationService**: Manages user authentication.
- **UserService**: Handles user management.
- **ProductService**: Manages product information.
- **OrderService**: Handles order processing.
- **CustomerService**: Manages customer information.

Each service includes:
- A project file (`*.csproj`) for dependencies.
- A `Program.cs` file as the entry point.
- A `Startup.cs` file for service configuration.
- Controllers for handling HTTP requests.
- Services containing business logic.
- Protos defining gRPC services and messages.

## Authentication

The application includes an authentication service that allows users to register and log in. This service is essential for managing access to different parts of the application.

## Running the Application

To run the application, follow these steps:

1. **Frontend**
   - Navigate to the `frontend` directory.
   - Install dependencies using `npm install`.
   - Start the development server with `npm run serve`.

2. **Backend**
   - Navigate to the `backend` directory.
   - Use Docker to run the services defined in `docker-compose.yml`.

## Conclusion

This sales application provides a comprehensive solution for managing sales processes, with a clear separation of concerns through microservices architecture. Each role has its dedicated interface, ensuring a smooth user experience.