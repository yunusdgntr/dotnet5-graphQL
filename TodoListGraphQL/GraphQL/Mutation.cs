using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using TodoListGraphQL.Api.Data;
using TodoListGraphQL.Api.GraphQL.DataItem;
using TodoListGraphQL.Api.GraphQL.Lists;
using TodoListGraphQL.Api.Models;

namespace TodoListGraphQL.Api.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddListPayload> AddListAsync(AddListInput input, [ScopedService] ApiDbContext context)
        {
            var list = new ItemList
            {
                Name = input.name
            };

            context.Lists.Add(list);
            await context.SaveChangesAsync();

            return new AddListPayload(list);
        }

        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddItemPayload> AddItemAsync(AddItemInput input, [ScopedService] ApiDbContext context,[Service]ITopicEventSender topicEventSender,CancellationToken cancelationToken)
        {
            var item = new Item
            {
                IsDone = input.isDone,
                Description = input.description,
                ListId = input.listId,
                Title = input.title
            };

            context.Items.Add(item);
            await context.SaveChangesAsync(cancelationToken);
            await topicEventSender.SendAsync(nameof(Subscription.OnItemAddded),item,cancelationToken);
            return new AddItemPayload(item);
        }
    }
}