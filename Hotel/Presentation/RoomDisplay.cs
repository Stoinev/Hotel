using Hotel.Business;
using Hotel.Controllers;
using Hotel.Data;
using Hotel.Data.Models;
using Hotel.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Presentation
{
    public class RoomDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<Room> roomController = new RoomController();
        public RoomDisplay()
        {
            Input();
        }
        public RoomDisplay(IController<Room> roomController)
        {
            Input();
            this.roomController = roomController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU ROOMS" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all rooms");
            Console.WriteLine("2. Add new room");
            Console.WriteLine("3. Update room");
            Console.WriteLine("4. Fetch room by ID");
            Console.WriteLine("5. Delete room by ID");
            Console.WriteLine("6. Menu");
        }

        public void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    case 6:
                        ShowMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
            } while (operation != closeOperationId);
        }

        public void Add()
        {
            try
            {
                Room newRoom = new Room();
                do
                {
                    Console.WriteLine("Enter room Id: ");
                    newRoom.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newRoom.Id));
                do
                {
                    Console.WriteLine("Enter room number: ");
                    newRoom.Number = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newRoom.Number));
                do
                {
                    Console.WriteLine("Enter room description: ");
                    newRoom.Description = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newRoom.Description));

                do
                {
                    Console.WriteLine("Enter price: ");
                    newRoom.Price = int.Parse(Console.ReadLine());
                }
                while (Validators.IsDoubleNoValid(newRoom.Price));

                Console.WriteLine("Enter Client Id:");
                List<int> clientId = Console.ReadLine().Split().Select(int.Parse).ToList();
                foreach (int id in clientId)
                {
                    Reservation reservation = new Reservation();
                    reservation.ClientId = id;
                    reservation.RoomId = newRoom.Id;
                    newRoom.Reservations.Add(reservation);
                }
                roomController.Add(newRoom);
                Console.WriteLine("Room add to database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete()
        {
            try
            {
                Room findRoom = new Room();
                do
                {
                    Console.WriteLine("Enter room Id to delete: ");
                    findRoom.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findRoom.Id));
                roomController.Delete(findRoom);
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Fetch()
        {
            try
            {
                Room findRoom = new Room();

                do
                {
                    Console.WriteLine("Enter room Id to fetch: ");
                    findRoom.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findRoom.Id));
                Room room = roomController.Get(findRoom);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Room ID: " + room.Id);
                Console.WriteLine("Price: " + room.Price);
                Console.WriteLine("Number: " + room.Number);
                Console.WriteLine("Description: " + room.Description);
                foreach (var client in room.Reservations)
                {
                    Console.WriteLine(client.ClientId);
                    Console.WriteLine(client.Client.FirstName + " " + client.Client.LastName);
                }
                Console.WriteLine(new string('-', 40));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update()
        {
            try
            {
                Room findRoom = new Room();
                do
                {
                    Console.WriteLine("Enter room Id to update: ");
                    findRoom.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findRoom.Id));
                do
                {
                    Console.WriteLine("Enter room number: ");
                    findRoom.Number = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findRoom.Number));
                do
                {
                    Console.WriteLine("Enter room description: ");
                    findRoom.Description = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findRoom.Description));
                do
                {
                    Console.WriteLine("Enter price: ");
                    findRoom.Price = int.Parse(Console.ReadLine());
                }
                while (Validators.IsDoubleNoValid(findRoom.Price));

                Console.WriteLine("Enter CLient Id by separator ' '");
                List<int> clientId = Console.ReadLine().Split().Select(int.Parse).ToList();
                foreach (int id in clientId)
                {
                    Reservation reservation = new Reservation();
                    reservation.ClientId = id;
                    reservation.RoomId = findRoom.Id;
                    findRoom.Reservations.Add(reservation);
                }

                roomController.Update(findRoom);
                Console.WriteLine("Room update to database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
 
        public void ListAll()
        {
            try
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 16) + "ROOMS" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var rooms = roomController.ListAll();
                foreach (var room in rooms)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("Room ID: " + room.Id);
                    Console.WriteLine("Number: " + room.Number);
                    Console.WriteLine("Price: " + room.Price);
                    Console.WriteLine("Description: " + room.Description);
                    foreach (var client in room.Reservations)
                    {
                        Console.WriteLine(client.ClientId);
                        Console.WriteLine(client.Client.FirstName + " " + client.Client.LastName);
                    }
                    Console.WriteLine(new string('-', 40));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
