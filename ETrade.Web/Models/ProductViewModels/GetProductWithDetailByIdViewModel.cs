using ETrade.Core.Entities.Abstract;

namespace ETrade.Web.Models.ProductViewModels
{
    public class GetProductWithDetailByIdViewModel : IViewModel
    {
        public int Id { get; set; }
        public string TradeMark { get; set; }
        public string Name { get; set; }
    }
}
