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
    public class ClientBusiness : ICRUD<Client>
    {
        private HotelDbContext hotelDbContext = new HotelDbContext();

        public ClientBusiness()
        {

        }
        public ClientBusiness(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;

        }
        public void Add(Client item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Clients.Add(item);
                hotelDbContext.SaveChanges();

            }
        }

        public void Delete(Client item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                var client = hotelDbContext.Clients.Find(item.Id);
                if (client != null)
                {
                    hotelDbContext.Clients.Remove(client);
                    hotelDbContext.SaveChanges();
                }
            }
        }

        public Client Get(Client item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                //moje greshka
                return hotelDbContext.Clients.Where(x => x.Id == item.Id).Include(x => x.Address).FirstOrDefault();
            }
        }


        public List<Client> GetAll()
        {
            using (hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Clients.Include(x => x.Address).ToList();
            }
        }

        public void Update(Client item)
        {
            using (hotelDbContext = new HotelDbContext())
            {

                var client = hotelDbContext.Clients.Find(item.Id);
                if (client != null)
                {
                    hotelDbContext.Entry(client).CurrentValues.SetValues(item);
                    hotelDbContext.SaveChanges();
                }
            }
        }
    }
}
