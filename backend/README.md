# Sales Application Backend

This backend service is part of a microservices architecture for a Sales Application. It consists of multiple services that communicate via gRPC. The services included are:

- **Authentication Service**: Handles user authentication, including login and registration.
- **User Service**: Manages user data and operations, allowing administrators to create and manage users.
- **Product Service**: Manages product data, allowing administrators to add and manage products.
- **Order Service**: Handles order processing, allowing sales personnel to collect and manage customer orders.
- **Customer Service**: Manages customer data and operations, allowing customers to place orders.

## Getting Started

### Prerequisites

- .NET SDK
- Docker (for running services in containers)

### Running the Application

1. Clone the repository:
   ```
   git clone <repository-url>
   cd sales-application/backend
   ```

2. Build and run the services using Docker Compose:
   ```
   docker-compose up --build
   ```

3. Access the services via their respective endpoints defined in the `docker-compose.yml` file.

### Service Communication

All services communicate using gRPC. Each service has its own proto files defining the service methods and message types. Ensure that you have the necessary gRPC tools installed to generate the required client and server code.

### Directory Structure

- **AuthenticationService**: Contains the authentication service implementation.
- **UserService**: Contains the user management service implementation.
- **ProductService**: Contains the product management service implementation.
- **OrderService**: Contains the order management service implementation.
- **CustomerService**: Contains the customer management service implementation.

### Contributing

Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

### License

This project is licensed under the MIT License. See the LICENSE file for more details.