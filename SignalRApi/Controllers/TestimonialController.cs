using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonailList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListtAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
               Comment = createTestimonialDto.Comment,
               ImageUrl = createTestimonialDto.ImageUrl,
               Name = createTestimonialDto.Name,
               Status = createTestimonialDto.Status,
               Title = createTestimonialDto.Title,
            });
            return Ok("Testimonial added");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Testimonial information deleted");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                Status = updateTestimonialDto.Status,
                Name = updateTestimonialDto.Name,
                ImageUrl=updateTestimonialDto.ImageUrl,
                TestimonalID = updateTestimonialDto.TestimonalID,
            });
            return Ok("Testimonial information updated");
        }
    }
}
