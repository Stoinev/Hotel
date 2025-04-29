using Hotel.Business;
using Hotel.Controllers;
using Hotel.Data;
using Hotel.Data.Models;
using Hotels.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class RoomController : IController<Room>
    {
        private ICRUD<Room> roomBusiness = new RoomBusiness();
        public RoomController()
        {

        }
        public RoomController(ICRUD<Room> roomBusiness)
        {
            this.roomBusiness = roomBusiness;
        }

        public void Add(Room newRoom)
        {
            Room room = roomBusiness.Get(newRoom);
            if (room != null)
            {
                throw new ArgumentException("Room with this code exists.");
            }
            roomBusiness.Add(newRoom);

        }

        public void Delete(Room findRoom)
        {
            Room room = roomBusiness.Get(findRoom);
            if (room != null)
            {
                roomBusiness.Delete(findRoom);
            }
            else
            {
                throw new ArgumentException("Room not found.");
            }
        }

        public Room Get(Room findRoom)
        {
            Room room = roomBusiness.Get(findRoom);
            if (room != null)
            {
                return room;
            }
            else
            {
                throw new ArgumentException("Room not found");
            }
        }

        public List<Room> ListAll()
        {
            var rooms = roomBusiness.GetAll();
            if (rooms.Count > 0)
            {
                return rooms;
            }
            else
            {
                throw new ArgumentException("The list is empty.");
            }

        }

        public void Update(Room findRoom)
        {
            Room room = roomBusiness.Get(findRoom);
            if (room != null)
            {
                roomBusiness.Update(findRoom);
            }
            else
            {
                throw new ArgumentException("Room not found.");
            }
        }
    }
}
