﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ETrade.Core.Entities.Abstract;

namespace ETrade.Web.Models.ProductViewModels
{
    public class UpdateProductViewModel : IViewModel
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
