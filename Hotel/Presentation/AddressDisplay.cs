using Hotel.Business;
using Hotel.Controllers;
using Hotel.Data;
using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Presentation
{
    public class AddressDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<Address> addressController = new AddressController();
        public AddressDisplay()
        {
            Input();
        }
        public AddressDisplay(IController<Address> addressController)
        {
            Input();
            this.addressController = addressController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU ADDRESSES " + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all addresses");
            Console.WriteLine("2. Add new address");
            Console.WriteLine("3. Update address");
            Console.WriteLine("4. Fetch address by ID");
            Console.WriteLine("5. Delete address by ID");
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
                Address newAddress = new Address();
                do
                {
                    Console.WriteLine("Enter address Id: ");
                    newAddress.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newAddress.Id));
                do
                {
                    Console.WriteLine("Enter name: ");
                    newAddress.Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newAddress.Name));
                do
                {
                    Console.WriteLine("Enter CityId: ");
                    newAddress.CityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newAddress.CityId));

                /*do
                {
                    Console.WriteLine("Enter school Id: ");
                    newAddress.SchoolId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newAddress.SchoolId));
                addressController.Add(newAddress);
                //todo school name*/
                addressController.Add(newAddress);
                Console.WriteLine("Address add to database.");

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
                Address findAddress = new Address();
                do
                {
                    Console.WriteLine("Enter address Id to delete: ");
                    findAddress.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findAddress.Id));
                addressController.Delete(findAddress);
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
                Address findAddress = new Address();
                do
                {
                    Console.WriteLine("Enter address Id to fetch: ");
                    findAddress.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findAddress.Id));

                Address address = addressController.Get(findAddress);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Address ID: " + address.Id);
                Console.WriteLine("Name: " + address.Name);
                Console.WriteLine("Град: " + address.CityId);
               // Console.WriteLine("School: " + address.School.Name);
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
                Address findAddress = new Address();
                do
                {
                    Console.WriteLine("Enter address Id to update: ");
                    findAddress.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findAddress.Id));
                do
                {
                    Console.WriteLine("Enter name: ");
                    findAddress.Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findAddress.Name));
                do
                {
                    Console.WriteLine("Enter CityID: ");
                    findAddress.CityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findAddress.CityId));

              /*  do
                {
                    Console.WriteLine("Enter school Id: ");
                    findAddress.SchoolId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findAddress.SchoolId));*/

                addressController.Update(findAddress);
                Console.WriteLine("Address update to database.");

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
                Console.WriteLine(new string(' ', 16) + "ADDRESSES " + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var addresss = addressController.ListAll();
                foreach (var address in addresss)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("Address ID: " + address.Id);
                    Console.WriteLine("name: " + address.Name);
                    Console.WriteLine("City " + address.CityId);
                 //   Console.WriteLine("School: " + address.School.Name);
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
