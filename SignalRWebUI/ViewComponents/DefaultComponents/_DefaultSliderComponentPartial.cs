using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> Invoke()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7063/api/Sliders");

            var jsonData = await responseMessage.Content.ReadAsStringAsync(); // string method 
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData); //list = deserialize,  add & update = serialize
            return View(values);
        }
    }
}
