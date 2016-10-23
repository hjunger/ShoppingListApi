namespace Domain.Entities
{
    public class Item : BaseEntity
    {
        public int ItemID
        {
            get { return Id; }
            set { Id = value; }
        }

        public string CustomerID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
