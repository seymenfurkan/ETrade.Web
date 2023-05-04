using AutoMapper;
using ETrade.Core.Entities.DTOs;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Business.Mapping.ForProduct
{
    public class DtoMapping : Profile
    {
        public DtoMapping()
        {
            CreateMap<Product , ProductDetailDto>().ReverseMap();
        }
    }
}
