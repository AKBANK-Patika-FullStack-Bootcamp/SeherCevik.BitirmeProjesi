using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteLibrary.Entities.DTO;
using SiteLibrary.Entities.Entities.Models;
using siteManagement.DataAccess;

namespace siteManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AptDbContext _context;
        public UserController(AptDbContext context)
        {
            _context = context;
        }
        //Result _result = new Result();


        [HttpGet("GetAll")]
        public Result<List<UserDTO>> GetAllUser()
        {

            var _result = new Result<List<UserDTO>>();
            var UserList = _context.user.ToList();
            var userListDto = UserList.Select(x => new UserDTO() { Name = x.Name, SurName = x.SurName, TcNo = x.TcNo,TelNumber=x.TelNumber, Email=x.Email });
            if (UserList.Count > 0)
            {
                _result.Status = true;
                _result.message = "User Of List";
                _result.Data = (List<UserDTO>)userListDto;
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
        public Result<List<UserDTO>> GetUser(int Id)
        {
            var _result = new Result<List<UserDTO>>();
            var ResultUser = _context.user.Where(User => User.Id == Id).ToList();
            var UserList = _context.user.ToList();
            var userListDto = UserList.Select(x => new UserDTO() { Name = x.Name, SurName = x.SurName, TcNo = x.TcNo, TelNumber = x.TelNumber, Email = x.Email });
            if (UserList.Count > 0)
            {
                _result.Status = true;
                _result.message = "Record Found:)";
                _result.Data = (List<UserDTO>)userListDto;
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
        public Result<List<UserDTO>> AddUser(UserDTO userDTO)
        {
            var _result = new Result<List<UserDTO>>();
            if (userDTO is not null)
            {
                //context işlemleri sadece entity nesnelerini kabul ettiği için parametreden gelen dto daki verileri bir adet entity nesnesi oluşturup onun içine atmamız gerekiyor. bu işleme de kavram olarak mappping işlemi denir.
                var user = new User()
                {
                    Name = userDTO.Name,
                    SurName = userDTO.SurName,
                    TcNo = userDTO.TcNo,
                    TelNumber = userDTO.TelNumber,
                    Email=userDTO.Email
   
                    //Kalan propert ler arka planda entitiy tarafından doldurulacak.
                };
                _context.user.Add(user);
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

        public Result<List<UserDTO>> Update(int Id, UserDTO userDTO)
        {
            var _result = new Result<List<UserDTO>>();
            //bir veritabanı ile çalışıyorsak artık bütün veritabanuı işlemlerimizde context nesnesini kullanmalıyız
            User? user = _context.user.FirstOrDefault(o => o.Id == Id);
            if (user != null)
            {
                user.Name = userDTO.Name;
                user.SurName = userDTO.SurName;
                user.TcNo = userDTO.TcNo;
                user.TelNumber = userDTO.TelNumber;
                user.Email = userDTO.Email;
                _context.SaveChanges();
                _result.Status = true;
                _result.message = "User Information updated";
            }
            else
            {
                _result.Status = false;
                _result.message = "This user information is not registered";
            }
            return _result;
        }

        //silme işlemini yapacak metod
        [HttpDelete("{Id}")]

        public Result<List<UserDTO>> Delete(int Id)
        {
            var _result = new Result<List<UserDTO>>();
            User? user = _context.user.FirstOrDefault(k => k.Id == Id);
            if (user is not null)
            {
                _context.Remove(user);
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
