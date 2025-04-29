using Hotel.Data;
using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Hotel.Business;

namespace Hotels.Business
{
    public class RoomBusiness : ICRUD<Room>
    {
        private HotelDbContext hotelDbContext = new HotelDbContext();

        public RoomBusiness()
        {

        }
        public RoomBusiness(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;

        }
        public void Add(Room item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Rooms.Add(item);
                hotelDbContext.SaveChanges();
            }
        }

        public void Delete(Room item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                var room = hotelDbContext.Rooms.Find(item.Id);
                if (room != null)
                {
                    hotelDbContext.Rooms.Remove(room);
                    hotelDbContext.SaveChanges();
                }
            }
        }

        public Room Get(Room item)
        {
            using (hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Rooms.Where(x => x.Id == item.Id).Include(x => x.Reservations).Include(x => x.Clients).FirstOrDefault();
             }
        }

        public List<Room> GetAll()
        {
            using (hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Rooms.Include(x => x.Reservations).Include(x => x.Clients).ToList();
            }
        }

        public void Update(Room item)
        {

            using (hotelDbContext = new HotelDbContext())
            {

                var room = hotelDbContext.Rooms.Find(item.Id);
                if (room != null)
                {
                    hotelDbContext.Entry(room).CurrentValues.SetValues(item);
                    hotelDbContext.SaveChanges();
                }

                var oldStudent = hotelDbContext.Reservations.Where(x => x.RoomId == item.Id).ToList();
                hotelDbContext.Reservations.RemoveRange(oldStudent);
                hotelDbContext.SaveChanges();
                hotelDbContext.Reservations.AddRange(item.Reservations);
                hotelDbContext.SaveChanges();
            }
        }
    }
}
