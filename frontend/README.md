# Sales Application Frontend

This is the frontend part of the Sales Application, built using Vue.js. The application consists of three main user roles: Admin, Sales Person, and Customer. Each role has its own dedicated views and components to manage their respective functionalities.

## Project Structure

- **src/**: Contains the source code for the application.
  - **components/**: Vue components for different user roles.
    - **AdminView.vue**: Admin interface for managing users and products.
    - **SalesPersonView.vue**: Sales person interface for collecting orders.
    - **CustomerView.vue**: Customer interface for making orders.
  - **views/**: Main views for each user role.
    - **Admin.vue**: Main view for the Admin interface.
    - **SalesPerson.vue**: Main view for the Sales Person interface.
    - **Customer.vue**: Main view for the Customer interface.
  - **App.vue**: Root component of the application.
  - **main.js**: Entry point of the Vue application.
  - **router.js**: Defines the routes for the application.

- **public/**: Contains public assets.
  - **index.html**: Main HTML file for the application.

- **package.json**: Configuration file for npm, listing dependencies and scripts.

## Installation

To get started with the frontend application, follow these steps:

1. Clone the repository:
   ```
   git clone <repository-url>
   cd sales-application/frontend
   ```

2. Install dependencies:
   ```
   npm install
   ```

3. Run the application:
   ```
   npm run serve
   ```

## Features

- **Admin View**: Manage users and products.
- **Sales Person View**: Collect and process customer orders.
- **Customer View**: Browse products and place orders.

## Technologies Used

- Vue.js: JavaScript framework for building user interfaces.
- gRPC: For service communication between frontend and backend.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.