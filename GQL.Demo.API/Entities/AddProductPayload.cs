using GraphDemo.GQLModels;

namespace GraphDemo.Entities
{
    public class AddProductPayload
    {
        public AddProductPayload(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}
