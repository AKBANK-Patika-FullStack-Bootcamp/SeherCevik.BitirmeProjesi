using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteLibrary.Entities.Entities.Models;
using siteManagement.Service;
using siteManagement.Settings;

namespace siteManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        CreditCardService _CreditCardService;

        public CreditCardController(IDbSettings settings)
        {
            _CreditCardService = new CreditCardService(settings);
        }

        //Tümünü Listeleme
        [HttpGet("GetAll")]
        public ActionResult<List<CreditCard>> GetAll() => _CreditCardService.GetAll();

        //Tek bir kredi kartı getirme
        [HttpGet("{id:length(24)}")]
        public ActionResult<CreditCard> Get(int id) => _CreditCardService.GetSingle(id);

        //Kredi kartı ekleme
        [HttpPost("Add")]
        public ActionResult<CreditCard> Add(CreditCard creditCard) => _CreditCardService.Add(creditCard);

        //Kredi kartı güncelleme.
        [HttpPut("Id")]
        public ActionResult Update(int Id,CreditCard currentUser)
        {
            var creditCard = _CreditCardService.GetSingle(Id);
            if (creditCard == null)
                return NotFound();

            _CreditCardService.Update(currentUser);
            return Ok();
        }

        //Kullanıcıyı silme
        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(int id)
        {
            var creditCard = _CreditCardService.GetSingle(id);

            if (creditCard == null)
                return NotFound();

            _CreditCardService.Delete(id);
            return Ok();
        }
    }
}

