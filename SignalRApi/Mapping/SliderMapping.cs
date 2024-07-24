using AutoMapper;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class SliderMapping :Profile
	{
        public SliderMapping()
        {
			CreateMap<Contact, ResultSliderDto>().ReverseMap();
		}
    }
}
