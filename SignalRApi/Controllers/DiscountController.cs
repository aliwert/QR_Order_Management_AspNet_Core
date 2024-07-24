using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult DiscountList()
		{
			var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListtAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			_discountService.TAdd(new Discount()
			{
				Amount = createDiscountDto.Amount,
				Description = createDiscountDto.Description,
				ImageUrl = createDiscountDto.ImageUrl,
				Title = createDiscountDto.Title,
				Status = false

			});
			return Ok("Discount added");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteDiscount(int id)
		{
			var value = _discountService.TGetByID(id);
			_discountService.TDelete(value);
			return Ok("Discount information deleted");
		}
		[HttpGet("{id}")]
		public IActionResult GetDiscount(int id)
		{
			var value = _discountService.TGetByID(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			_discountService.TUpdate(new Discount()
			{
				DiscountID = updateDiscountDto.DiscountID,
				Title = updateDiscountDto.Title,
				Description = updateDiscountDto.Description,
				ImageUrl = updateDiscountDto.ImageUrl,
				Amount = updateDiscountDto.Amount,
				Status = false

			});
			return Ok("Discount information updated");
		}
		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok("Product discount activated");
		}
		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Product discount inactivated");
		}
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            return Ok(_discountService.TGetListByStatusTrue());
        }
    }
}
