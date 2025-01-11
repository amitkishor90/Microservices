using AutoMapper;
using Mango.Services.PRoductAPI.Models;
using Mango.Services.PRoductAPI.Models.Dto;

namespace Mango.Services.PRoductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
