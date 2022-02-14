using SiteLibrary.Entities.Entities.Models;
using siteManagement.DataAccess;

namespace siteManagement
{
    public class ApplicationInitializer
    {
        private readonly AptDbContext _context;

        public ApplicationInitializer(AptDbContext context)
        {
            _context = context;
        }

        public async Task StartAsync()
        {
            await RoleSeed();
            await ApartmentTypeSeed();
            await InvoiceTypeSeed();
        }


        private async Task<bool> RoleSeed()
        {

            if (_context.Roles.Count() == 0)
            {

                var recordList = new List<Role>(){

                         new Role{
                             Name = "Admin",
                         },
                           new Role{
                             Name = "User",
                         }

                    };

                await _context.Roles.AddRangeAsync(recordList);
                await _context.SaveChangesAsync();

                return true;
            }



            return false;
        }

        private async Task<bool> ApartmentTypeSeed()
        {

            if (_context.ApartmentTypes.Count() == 0)
            {

                var recordList = new List<ApartmentType>(){

                         new ApartmentType{
                             Name = "1+1",
                         },
                         new ApartmentType{
                             Name = "2+1",
                         },
                           new ApartmentType{
                             Name = "3+1",
                         },
                           new ApartmentType{
                             Name = "4+1",
                         }

                    };

                await _context.ApartmentTypes.AddRangeAsync(recordList);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }


        private async Task<bool> InvoiceTypeSeed()
        {

            if (_context.InvoiceTypes.Count() == 0)
            {

                var recordList = new List<InvoiceType>(){

                         new InvoiceType{
                             Name = "Aidat",
                         },
                         new InvoiceType{
                             Name = "Su Faturası",
                         },
                           new InvoiceType{
                             Name = "Elektrik Faturası",
                         },
                           new InvoiceType{
                             Name = "Doğalgaz Faturası",
                         }

                    };

                await _context.InvoiceTypes.AddRangeAsync(recordList);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
