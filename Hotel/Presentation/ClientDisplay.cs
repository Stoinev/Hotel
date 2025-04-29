using Hotel.Business;
using Hotel.Controllers;
using Hotel.Data;
using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Presentation
{
    public class ClientDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<Client> clientController = new ClientController();
        public ClientDisplay()
        {
            Input();
        }
        public ClientDisplay(IController<Client> clientController)
        {
            Input();
            this.clientController = clientController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU CLIENTS" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all clientes");
            Console.WriteLine("2. Add new client");
            Console.WriteLine("3. Update client");
            Console.WriteLine("4. Fetch client by ID");
            Console.WriteLine("5. Delete client by ID");
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
                Client newClient = new Client();
                do
                {
                    Console.WriteLine("Enter client Id: ");
                    newClient.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newClient.Id));
                do
                {
                    Console.WriteLine("Enter First name: ");
                    newClient.FirstName = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newClient.FirstName));
                do
                {
                    Console.WriteLine("Enter Last name: ");
                    newClient.LastName = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newClient.LastName));
                do
                {
                    Console.WriteLine("Enter Phone: ");
                    newClient.Phone = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newClient.Phone));
                do
                {
                    Console.WriteLine("Enter Email: ");
                    newClient.Email = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newClient.Email));
                do
                {
                    Console.WriteLine("Enter address Id: ");
                    newClient.AddressId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newClient.AddressId));
                //mai adres
                /*do
                {
                    Console.WriteLine("Enter school Id: ");
                    newClient.SchoolId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newClient.SchoolId));
                clientController.Add(newClient);
                //todo school name*/
                clientController.Add(newClient);
                Console.WriteLine("Client add to database.");

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
                Client findClient = new Client();
                do
                {
                    Console.WriteLine("Enter client Id to delete: ");
                    findClient.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findClient.Id));
                clientController.Delete(findClient);
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
                Client findClient = new Client();
                do
                {
                    Console.WriteLine("Enter client Id to fetch: ");
                    findClient.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findClient.Id));

                Client client = clientController.Get(findClient);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Client ID: " + client.Id);
                Console.WriteLine("Name: " + client.FirstName);
                Console.WriteLine("Last Name: " + client.LastName);
                Console.WriteLine("Телефон: "  + client.Phone);
                Console.WriteLine("Имейл: " + client.Email);
                Console.WriteLine("Град: " + client.AddressId);
                // Console.WriteLine("School: " + client.School.Name);
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
                Client findClient = new Client();
                do
                {
                    Console.WriteLine("Enter client Id to update: ");
                    findClient.Id = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findClient.Id));
                do
                {
                    Console.WriteLine("Enter first name: ");
                    findClient.FirstName = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findClient.FirstName));
                do
                {
                    Console.WriteLine("Enter last name: ");
                    findClient.LastName = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findClient.LastName));
                do
                {
                    Console.WriteLine("Enter Phone: ");
                    findClient.Phone = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findClient.Phone));
                do
                {
                    Console.WriteLine("Enter Email: ");
                    findClient.Email = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findClient.Email));

                do
                {
                    Console.WriteLine("Enter address Id: ");
                    findClient.AddressId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findClient.AddressId));


                /*  do
                  {
                      Console.WriteLine("Enter school Id: ");
                      findClient.SchoolId = int.Parse(Console.ReadLine());
                  }
                  while (Validators.IsIntNoValid(findClient.SchoolId));*/

                clientController.Update(findClient);
                Console.WriteLine("Client update to database.");

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
                Console.WriteLine(new string(' ', 16) + "CLIENTS" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var clients = clientController.ListAll();
                foreach (var client in clients)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("Client ID: " + client.Id);
                    Console.WriteLine("First name: " + client.FirstName);
                    Console.WriteLine("Last name: " + client.LastName);
                    Console.WriteLine("Phone number: " + client.Phone);
                    Console.WriteLine("Email address " + client.Email);
                    Console.WriteLine("Address ID " + client.AddressId);
                    //   Console.WriteLine("School: " + client.School.Name);
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
