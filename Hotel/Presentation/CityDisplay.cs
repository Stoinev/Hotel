using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Business;
using Hotel.Controllers;
using Hotel.Data;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Mysqlx.Crud;
using Mysqlx.Cursor;
using Org.BouncyCastle.Bcpg;

namespace Hotel.Presentation
{
    public class CityDisplay : IDisplay
    {
        private int closeOperationID = 6;
        private IController<City> cityController = new CityController();

        public CityDisplay()
        {
            Input();
        }
        public CityDisplay(IController<City> cityController)
        {
            Input();
            this.cityController = cityController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU CITIES" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all cities");
            Console.WriteLine("2. Add new city");
            Console.WriteLine("3. Update city");
            Console.WriteLine("4. Fetch city by Id");
            Console.WriteLine("5. Delete city by Id");
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
            } while (operation != closeOperationID);
        }

        public void Add()
        {
            try
            {
                City city = new City();
                do
                {
                    Console.WriteLine("Enter ID:");
                    city.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(city.Id));
                do
                {
                    Console.WriteLine("Enter name:");
                    city.Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(city.Name));
                cityController.Add(city);
                Console.WriteLine("City add to database.");
            }
            catch   (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete()
        {
            try
            {
                City findcity = new City();
                do
                {
                    Console.WriteLine("Enter city ID:");
                    findcity.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findcity.Id));
                cityController.Delete(findcity);
                Console.WriteLine("Done");
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
                City findcity = new City();

                do
                {
                    Console.WriteLine("Enter city ID:");
                    findcity.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findcity.Id));
                City city=cityController.Get(findcity);
                Console.WriteLine(new string('-',40));
                Console.WriteLine("ID: "+city.Id);
                Console.WriteLine("Name: " + city.Name);
                //posible misstake
                foreach (Address address in city.Addresses)
                {
                    Console.WriteLine("Address: "+address.Id);
                    Console.WriteLine("Name: "+address.Name);
                }//maybe if maybe no
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
                City findcity = new City();
                do
                {
                    Console.WriteLine("Enter city ID:");
                    findcity.Id = int.Parse(Console.ReadLine());
                } 
                while (Validators.IsIntNoValid(findcity.Id));
                do
                {
                    Console.WriteLine("Enter name:");
                    findcity.Name = Console.ReadLine();
                } while (Validators.IsStringNoValid(findcity.Name));
                cityController.Update(findcity);
                Console.WriteLine("City update to database.");
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
                Console.WriteLine(new string('-', 16)+"CITY "+ new string('-', 16));
                Console.WriteLine(new string('-', 40));
                var City = cityController.ListAll();
                foreach (var city in City)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("ID: " + city.Id);
                    Console.WriteLine("Name: " + city.Name);
                    foreach (Address address in city.Addresses)
                    {
                        Console.WriteLine("Address: " + address.Id);
                        Console.WriteLine("Name: " + address.Name);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //maybe if maybe no
        }
    }
}


