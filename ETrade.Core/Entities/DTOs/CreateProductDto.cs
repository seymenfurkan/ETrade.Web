using ETrade.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core.Entities.DTOs
{
    public class CreateProductDto : IDto
    {
        public string TradeMark { get; set; }

        [Required(ErrorMessage = "İsim alanı boş bırakılamaz !")]
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
