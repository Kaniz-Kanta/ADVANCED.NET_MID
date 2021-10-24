using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Category.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public int P_Name { get; set; }
    }
}