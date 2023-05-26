namespace AutoMapperPractice.Model.DTO
{
    internal class ProductCreReq
    {
        public ProductCreReq(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductCreReq()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public override string? ToString()
        {
            return string.Format("{0}, {1}, {2}", Name, Description, Price);
        }
    }
}
