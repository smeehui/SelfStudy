using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Model.DTO
{
    internal class ProductRes
    {
        public ProductRes()
        {
        }

        public ProductRes(int id, string name, string description, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public override string? ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", Id, Name, Description, Price);
        }
    }
}
