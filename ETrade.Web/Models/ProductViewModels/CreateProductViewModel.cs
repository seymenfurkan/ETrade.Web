using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ETrade.Core.Entities.Abstract;

namespace ETrade.Web.Models.ProductViewModels
{
    public class CreateProductViewModel :IViewModel
    {
        public string TradeMark { get; set; }

        [Required(ErrorMessage = "İsim alanı boş bırakılamaz !")]
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
