using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListtAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
               Mail = createMessageDto.Mail,
               MessageContent = createMessageDto.MessageContent,
               MessageSendDate = DateTime.Now,
               NameSurname = createMessageDto.NameSurname,
               Phone = createMessageDto.Phone,
               Status = createMessageDto.Status,
               Subject = createMessageDto.Subject,
            };
            _messageService.TAdd(message);
            return Ok("Message section has been successfully added.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Message section has been successfully deleted");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                Mail = updateMessageDto.Mail,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = DateTime.Now,
                NameSurname = updateMessageDto.NameSurname,
                Phone = updateMessageDto.Phone,
                Status = updateMessageDto.Status,
                Subject = updateMessageDto.Subject,
            };
            _messageService.TUpdate(message);
            return Ok("Message section has been succesfully update");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(value);
        }
    }
}
