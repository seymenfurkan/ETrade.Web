using ETrade.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core.Entities.DTOs
{
    public class DeleteProductDto : IDto
    {
        public int Id { get; set; }
    }
}
