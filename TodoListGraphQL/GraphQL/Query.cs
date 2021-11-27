using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using TodoListGraphQL.Api.Data;
using TodoListGraphQL.Api.Models;

namespace TodoListGraphQL.Api.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetList([ScopedService] ApiDbContext context)
        {
            return context.Lists;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Item> GetDatas([ScopedService] ApiDbContext context)
        {
            return context.Items;
        }
    }
}