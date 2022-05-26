using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.SelectedProducts
{
    public class SelectedProductHelper : IMapWith<SelectedProduct>
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SelectedProductHelper, SelectedProduct>()
                .ForMember(selectedProduct => selectedProduct.ProductId, 
                opt => opt.MapFrom(selectedProductHelper => selectedProductHelper.ProductId))
                .ForMember(selectedProduct => selectedProduct.Count, 
                opt => opt.MapFrom(selectedProductHelper => selectedProductHelper.Count));
        }
    }
}
