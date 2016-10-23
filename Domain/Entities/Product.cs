using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public int ProductID { get { return Id; } set { Id = value; } }
        public string Type { get; set; }

        public List<Item> Items { get; set; }
    }
}
