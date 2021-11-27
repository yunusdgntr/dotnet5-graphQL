using HotChocolate;
using HotChocolate.Types;
using TodoListGraphQL.Api.Models;

namespace TodoListGraphQL.Api.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Item OnItemAddded([EventMessage] Item itemData)
        {
            return itemData;
        }

    }
}
