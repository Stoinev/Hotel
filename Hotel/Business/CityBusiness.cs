using Hotel.Data;
using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Business
{
    public class CityBusiness : ICRUD<City>
    {
        private HotelDbContext hotelDbContext = new HotelDbContext();

        public CityBusiness()
        {

        }
        public CityBusiness(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;

        }
        public void Add(City item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Cities.Add(item);
                hotelDbContext.SaveChanges();

            }
        }

        public void Delete(City item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                var city = hotelDbContext.Cities.Find(item.Id);
                if (city != null)
                {
                    hotelDbContext.Cities.Remove(city);
                    hotelDbContext.SaveChanges();
                }
            }
        }

        public City Get(City item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                //moje greshka
                return hotelDbContext.Cities.Where(x => x.Id == item.Id).Include(x => x.Addresses).FirstOrDefault();
            }
        }


        public List<City> GetAll()
        {
            using (hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Cities.Include(x => x.Addresses).ToList();
            }
        }

        public void Update(City item)
        {
            using (hotelDbContext = new HotelDbContext())
            {

                var city = hotelDbContext.Cities.Find(item.Id);
                if (city != null)
                {
                    hotelDbContext.Entry(city).CurrentValues.SetValues(item);
                    hotelDbContext.SaveChanges();
                }
            }
        }
    }
}
