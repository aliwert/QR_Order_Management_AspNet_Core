using AutoMapper;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class DiscountMapping: Profile
    {
        // Constructor to configure the mappings
        public DiscountMapping()
        {
            // Map between Discount entity and ResultDiscountDto, allowing reverse mapping
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            // Map between Discount entity and CreateDiscountDto, allowing reverse mapping
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            // Map between Discount entity and UpdateDiscountDto, allowing reverse mapping
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            // Map between Discount entity and GetDiscountDto, allowing reverse mapping
            CreateMap<Discount, GetDiscountDto>().ReverseMap();

        }
    }
}
