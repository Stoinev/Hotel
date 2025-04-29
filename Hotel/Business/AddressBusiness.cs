
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Data;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Business
{
    public class AddressBusiness : ICRUD<Address>
    {
        private HotelDbContext hotelDbContext = new HotelDbContext();

        public AddressBusiness()
        {

        }
        public AddressBusiness(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;

        }
        public void Add(Address item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Addresses.Add(item);
                hotelDbContext.SaveChanges();

            }
        }

        public void Delete(Address item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                var address = hotelDbContext.Addresses.Find(item.Id);
                if (address != null)
                {
                    hotelDbContext.Addresses.Remove(address);
                    hotelDbContext.SaveChanges();
                }
            }
        }

        public Address Get(Address item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                //moje greshka
                return hotelDbContext.Addresses.Where(x => x.Id == item.Id).Include(x => x.City).FirstOrDefault();
            }
        }


        public List<Address> GetAll()
        {
            using (hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Addresses.Include(x => x.City).ToList();
            }
        }

        public void Update(Address item)
        {
            using (hotelDbContext = new HotelDbContext())
            {

                var address = hotelDbContext.Addresses.Find(item.Id);
                if (address != null)
                {
                    hotelDbContext.Entry(address).CurrentValues.SetValues(item);
                    hotelDbContext.SaveChanges();
                }
            }
        }
    }
}
