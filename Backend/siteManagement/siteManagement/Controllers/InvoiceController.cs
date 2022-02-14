using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteLibrary.Entities.DTO;
using SiteLibrary.Entities.Entities.Models;
using siteManagement.DataAccess;

namespace siteManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly AptDbContext _context;
        public InvoiceController(AptDbContext context)
        {
            _context = context;
        }
        //Result _result = new Result();


        [HttpGet("GetAll")]
        public Result<List<InvoiceDTO>> GetAllInvoice()
        {

            var _result = new Result<List<InvoiceDTO>>();
            var InvoiceList = _context.invoice.ToList();
            var invoiceListDto = InvoiceList.Select(x => new InvoiceDTO() { TotalPrice = x.TotalPrice, PaidPrice = x.PaidPrice, Debt = x.Debt});
            if (InvoiceList.Count > 0)
            {
                _result.Status = true;
                _result.message = "Invoice Of List";
                _result.Data = (List<InvoiceDTO>)invoiceListDto;
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
        public Result<List<InvoiceDTO>> GetInvoice(int Id)
        {
            var _result = new Result<List<InvoiceDTO>>();
            var ResultInvoice = _context.invoice.Where(invoice => invoice.Id == Id).ToList();
            var InvoiceList = _context.invoice.ToList();
            var invoiceListDto = InvoiceList.Select(x => new InvoiceDTO() { TotalPrice = x.TotalPrice, PaidPrice = x.PaidPrice, Debt = x.Debt });
            if (InvoiceList.Count > 0)
            {
                _result.Status = true;
                _result.message = "Record Found:)";
                _result.Data = (List<InvoiceDTO>)invoiceListDto;
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
        public Result<List<InvoiceDTO>> AddInvoice(InvoiceDTO invoiceDTO)
        {
            var _result = new Result<List<InvoiceDTO>>();
            if (invoiceDTO is not null)
            {
                //context işlemleri sadece entity nesnelerini kabul ettiği için parametreden gelen dto daki verileri bir adet entity nesnesi oluşturup onun içine atmamız gerekiyor. bu işleme de kavram olarak mappping işlemi denir.
                var invoice= new Invoice()
                {
                    TotalPrice = invoiceDTO.TotalPrice,
                    PaidPrice = invoiceDTO.PaidPrice,
                    Debt = invoiceDTO.Debt,

                    //Kalan propert ler arka planda entitiy tarafından doldurulacak.
                };
                _context.invoice.Add(invoice);
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

        public Result<List<InvoiceDTO>> Update(int Id, InvoiceDTO invoiceDTO)
        {
            var _result = new Result<List<InvoiceDTO>>();
            //bir veritabanı ile çalışıyorsak artık bütün veritabanuı işlemlerimizde context nesnesini kullanmalıyız
            Invoice? invoice = _context.invoice.FirstOrDefault(o => o.Id == Id);
            if (invoice != null)
            {
                invoice.TotalPrice = invoiceDTO.TotalPrice;
                invoice.PaidPrice = invoiceDTO.PaidPrice;
                invoice.Debt = invoiceDTO.Debt;
                _context.SaveChanges();
                _result.Status = true;
                _result.message = "Invoice Information updated";
            }
            else
            {
                _result.Status = false;
                _result.message = "This ınvoice information is not registered";
            }
            return _result;
        }

        //silme işlemini yapacak metod
        [HttpDelete("{Id}")]

        public Result<List<InvoiceDTO>> Delete(int Id)
        {
            var _result = new Result<List<InvoiceDTO>>();
            Invoice? invoice = _context.invoice.FirstOrDefault(o => o.Id == Id);
            if (invoice is not null)
            {
                _context.Remove(invoice);
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
