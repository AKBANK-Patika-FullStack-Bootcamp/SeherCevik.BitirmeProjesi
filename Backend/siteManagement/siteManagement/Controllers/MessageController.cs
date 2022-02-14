using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteLibrary.Entities.DTO;
using SiteLibrary.Entities.Entities.Models;
using siteManagement.DataAccess;

namespace siteManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly AptDbContext _context;
        public MessageController(AptDbContext context)
        {
            _context = context;
        }
        //Result _result = new Result();


        [HttpGet("GetAll")]
        public Result<List<MessageDTO>> GetAllMessage()
        {

            var _result = new Result<List<MessageDTO>>();
            var MessageList = _context.messages.ToList();
            var messageListDto = MessageList.Select(x => new MessageDTO() { Seen = x.Seen, Content = x.Content });
            if (MessageList.Count > 0)
            {
                _result.Status = true;
                _result.message = "Message Of List";
                _result.Data = (List<MessageDTO>)messageListDto;
            }
            else
            {
                _result.Status = false;
                _result.message = "No Records Found!";
            }
            return _result;
        }

        //Sadece Id sini verdiğimiz apt yi getirecek metod.

        [HttpGet("{Id}")]
        public Result<List<MessageDTO>> GetMessage(int Id)
        {
            var _result = new Result<List<MessageDTO>>();
            var ResultMessage = _context.messages.Where(Message => Message.Id == Id).ToList();
            var MessageList = _context.messages.ToList();
            var messageListDto = MessageList.Select(x => new MessageDTO() { Seen = x.Seen, Content = x.Content });
            if (MessageList.Count > 0)
            {
                _result.Status = true;
                _result.message = "Record Found:)";
                _result.Data = (List<MessageDTO>)messageListDto;
            }
            else
            {
                _result.Status = false;
                _result.message = "No Records Found!";
            }
            return _result;


        }


        //Add metodunun çalışması için Dto sınıfının oluşturulmuş olması gerekir.
        [HttpPost("Add")]
        public Result<List<MessageDTO>> AddMessage(MessageDTO messageDTO)
        {
            var _result = new Result<List<MessageDTO>>();
            if (messageDTO is not null)
            {
                //context işlemleri sadece entity nesnelerini kabul ettiği için parametreden gelen dto daki verileri bir adet entity nesnesi oluşturup onun içine atmamız gerekiyor. bu işleme de kavram olarak mappping işlemi denir.
                var message = new Message()
                {
                    Seen = messageDTO.Seen,
                    Content = messageDTO.Content,
                    //Kalan propert ler arka planda entitiy tarafından doldurulacak.
                };
                _context.messages.Add(message);
                _context.SaveChanges();
                _result.Status = true;
                _result.message = "Registration successfully added";
            }
            else
            {
                _result.Status = false;
                _result.message = "Failed";
            }
            return _result;
        }

        //Güncelleme yapacak metod
        [HttpPut("Id")]

        public Result<List<MessageDTO>> Update(int Id, MessageDTO messageDTO)
        {
            var _result = new Result<List<MessageDTO>>();
            //bir veritabanı ile çalışıyorsak artık bütün veritabanuı işlemlerimizde context nesnesini kullanmalıyız
            Message? message = _context.messages.FirstOrDefault(o => o.Id == Id);
            if (message != null)
            {
                message.Seen = messageDTO.Seen;
                message.Content = messageDTO.Content;
                _context.SaveChanges();
                _result.Status = true;
                _result.message = "message Information updated";
            }
            else
            {
                _result.Status = false;
                _result.message = "This message information is not registered";
            }
            return _result;
        }

        //silme işlemini yapacak metod
        [HttpDelete("{Id}")]

        public Result<List<MessageDTO>> Delete(int Id)
        {
            var _result = new Result<List<MessageDTO>>();
            Message? message = _context.messages.FirstOrDefault(k => k.Id == Id);
            if (message is not null)
            {
                _context.Remove(message);
                _context.SaveChanges();
                _result.Status = true;
                _result.message = "This record has been deleted";

            }
            else
            {
                _result.Status = false;
                _result.message = "This record not found";
            }
            return _result;

        }
    }
}
