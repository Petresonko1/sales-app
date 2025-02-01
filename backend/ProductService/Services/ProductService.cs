using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using ProductService.Protos;

namespace ProductService.Services
{
    public class ProductService : ProductServiceBase
    {
        private readonly List<Product> products = new List<Product>();

        public override Task<AddProductResponse> AddProduct(AddProductRequest request, ServerCallContext context)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price
            };
            products.Add(product);

            return Task.FromResult(new AddProductResponse { Success = true });
        }

        public override Task<GetProductsResponse> GetProducts(GetProductsRequest request, ServerCallContext context)
        {
            var response = new GetProductsResponse();
            response.Products.AddRange(products);
            return Task.FromResult(response);
        }

        public override Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
        {
            var product = products.Find(p => p.Id == request.Id);
            if (product != null)
            {
                products.Remove(product);
                return Task.FromResult(new DeleteProductResponse { Success = true });
            }
            return Task.FromResult(new DeleteProductResponse { Success = false });
        }
    }
}