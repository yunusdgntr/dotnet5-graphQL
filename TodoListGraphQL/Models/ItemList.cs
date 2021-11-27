using System.Collections.Generic;

namespace TodoListGraphQL.Api.Models
{
    public class ItemList
    {
        public ItemList()
        {
            ItemDatas = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> ItemDatas {get;set;}
    }
}