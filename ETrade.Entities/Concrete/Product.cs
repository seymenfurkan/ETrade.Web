using ETrade.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string TradeMark { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }


        [RegularExpression("\"^\\\\d+(\\\\.\\\\d{0,2})$\"")]

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
