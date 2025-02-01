using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using CustomerService.Protos;

namespace CustomerService.Services
{
    public class CustomerService : CustomerServiceBase
    {
        private readonly List<Customer> customers = new List<Customer>();

        public override Task<AddCustomerResponse> AddCustomer(AddCustomerRequest request, ServerCallContext context)
        {
            var customer = new Customer
            {
                Id = request.Customer.Id,
                Name = request.Customer.Name,
                Email = request.Customer.Email
            };
            customers.Add(customer);

            return Task.FromResult(new AddCustomerResponse { Success = true });
        }

        public override Task<GetCustomersResponse> GetCustomers(GetCustomersRequest request, ServerCallContext context)
        {
            var response = new GetCustomersResponse();
            response.Customers.AddRange(customers);
            return Task.FromResult(response);
        }

        public override Task<DeleteCustomerResponse> DeleteCustomer(DeleteCustomerRequest request, ServerCallContext context)
        {
            var customer = customers.Find(c => c.Id == request.Id);
            if (customer != null)
            {
                customers.Remove(customer);
                return Task.FromResult(new DeleteCustomerResponse { Success = true });
            }
            return Task.FromResult(new DeleteCustomerResponse { Success = false });
        }
    }
}