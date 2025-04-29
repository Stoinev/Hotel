using Hotel.Business;
using Hotel.Controllers;
using Hotel.Data;
using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class ClientController : IController<Client>
    {
        private ICRUD<Client> clientBusiness = new ClientBusiness();
        public ClientController()
        {

        }
        public ClientController(ICRUD<Client> clientBusiness)
        {
            this.clientBusiness = clientBusiness;
        }
        public void Add(Client newClient)
        {
            Client client = clientBusiness.Get(newClient);
            if (client != null)
            {
                throw new ArgumentException("Client with this code exists.");
            }
            clientBusiness.Add(newClient);
            //todo school name

        }

        public void Delete(Client findClient)
        {
            Client client = clientBusiness.Get(findClient);
            if (client != null)
            {
                clientBusiness.Delete(findClient);
            }
            else
            {
                throw new ArgumentException("Client not found.");
            }
        }

        public Client Get(Client findClient)
        {

            Client client = clientBusiness.Get(findClient);
            if (client != null)
            {
                return client;
            }
            else
            {
                throw new ArgumentException("Client not found");
            }
        }

        public List<Client> ListAll()
        {
            var clients = clientBusiness.GetAll();
            if (clients.Count > 0)
            {
                return clients;
            }
            else
            {
                throw new ArgumentException("The list is empty.");
            }
        }

        public void Update(Client findClient)
        {

            Client client = clientBusiness.Get(findClient);
            if (client != null)
            {

                clientBusiness.Update(findClient);
            }
            else
            {
                throw new ArgumentException("Client not found.");
            }
        }
    }
}
