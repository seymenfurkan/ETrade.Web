using ETrade.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core.Entities.DTOs
{
    // What is DTO ? How to use and how should use DTO ? I Got it !
    public class ProductDetailDto : IDto
    {
        public int Id { get; set; }
        public string  TradeMark { get; set; }
        public string Name { get; set; }
    }
}
