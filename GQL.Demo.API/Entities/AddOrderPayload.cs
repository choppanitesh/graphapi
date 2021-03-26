using GraphDemo.GQLModels;

namespace GraphDemo.Entities
{
    public class AddOrderPayload
    {
        public AddOrderPayload(Orders orders)
        {
            Orders = orders;
        }

        public Orders Orders { get; }
    }
}
