using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteLibrary.Entities.DTO;
using SiteLibrary.Entities.Entities.Models;
using siteManagement.DataAccess;

namespace siteManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AptController : ControllerBase
    {
        //Bu controller da dependensies injection ile controllerımıza dahil edeceğimiz boş bir context nesnesi oluşturduk. Nesneyi dışarıdan gelen bir parametre ile dolduracağız. Bunu controller ın constructor unda yapacağız.
        private readonly AptDbContext _context;
        public AptController(AptDbContext context)
        {
            _context = context;
        }
        //Result _result = new Result();


        [HttpGet("GetAll")]
        public Result<List<AptDTO>> GetAllApt()
        {

            var _result = new Result<List<AptDTO>>();
            var AptList = _context.apts.ToList();
            var aptListDto = AptList.Select(x => new AptDTO() { FloorNumber = x.FloorNumber, UserId = x.UserId, BlockNum = x.BlockNum });
            if (AptList.Count > 0)
            {
                _result.Status = true;
                _result.message = "Apt Of List";
                _result.Data = (List<AptDTO>)aptListDto;
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
        public Result<List<AptDTO>> GetApt(int Id)
        {
            var _result = new Result<List<AptDTO>>();
            var ResultApt = _context.apts.Where(Apt => Apt.Id == Id).ToList();
            var AptList = _context.apts.ToList();
            var aptListDto = AptList.Select(x => new AptDTO() { FloorNumber = x.FloorNumber, UserId = x.UserId, BlockNum = x.BlockNum });
            if (AptList.Count > 0)
            {
                _result.Status = true;
                _result.message = "Record Found:)";
                _result.Data = (List<AptDTO>)aptListDto;
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
        public Result<List<AptDTO>> AddApt(AptDTO aptDTO)
        {
            var _result = new Result<List<AptDTO>>();
            if (aptDTO is not null)
            {
                //context işlemleri sadece entity nesnelerini kabul ettiği için parametreden gelen dto daki verileri bir adet entity nesnesi oluşturup onun içine atmamız gerekiyor. bu işleme de kavram olarak mappping işlemi denir.
                var apt = new Apartment()
                {
                    FloorNumber = aptDTO.FloorNumber,
                    BlockNum = aptDTO.BlockNum,
                    UserId = aptDTO.UserId
                    //Kalan propert ler arka planda entitiy tarafından doldurulacak.
                };
                _context.apts.Add(apt);
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
        public Result<List<AptDTO>> Update(int Id, AptDTO aptDTO)
        {
            var _result = new Result<List<AptDTO>>();
            //bir veritabanı ile çalışıyorsak artık bütün veritabanuı işlemlerimizde context nesnesini kullanmalıyız
            Apartment? apartment = _context.apts.FirstOrDefault(o => o.Id == Id);
            if (apartment != null)
            {
                apartment.FloorNumber = aptDTO.FloorNumber;
                apartment.BlockNum=aptDTO.BlockNum;
                apartment.UserId = aptDTO.UserId;
                _context.SaveChanges();
                _result.Status = true;
                _result.message = "Apartment Information updated";
            }
            else
            {
                _result.Status = false;
                _result.message = "This apartment information is not registered";
            }
            return _result;
        }

        //silme işlemini yapacak metod
        [HttpDelete("{Id}")]
        public Result<List<AptDTO>> Delete(int Id)
        {
            var _result = new Result<List<AptDTO>>();
            Apartment? apartment = _context.apts.FirstOrDefault(k => k.Id == Id);
            if (apartment is not null)
            {
                _context.Remove(apartment);
                _context.SaveChanges();
                _result.Status = true;
                _result.message = "This record has been deleted";

            }
            else
            {
                _result.Status = false;
                _result.message= "This record not found";
            }
            return _result;

        }


    }
}





