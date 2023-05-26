using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Model.DTO
{
    internal class ProductUpReq
    {
        public ProductUpReq(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductUpReq()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
