using AutoMapper;
using ProductApi.Models;
using ProductApi.Resources;
using System;

namespace ProductApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductResource, Product>()
                               .ForMember(d => d.CreatedDate, otp => otp.MapFrom(src => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Azerbaijan Standard Time"))))
                               .ForMember(d => d.IsDeleted,otp=>otp.MapFrom(src=>true));
        }
    }
}
