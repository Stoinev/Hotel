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
    public class AddressController : IController<Address>
    {
        private ICRUD<Address> addressBusiness = new AddressBusiness();
        public AddressController()
        {

        }
        public AddressController(ICRUD<Address> addressBusiness)
        {
            this.addressBusiness = addressBusiness;
        }
        public void Add(Address newAddress)
        {
            Address address = addressBusiness.Get(newAddress);
            if (address != null)
            {
                throw new ArgumentException("Address with this code exists.");
            }
            addressBusiness.Add(newAddress);
            //todo school name

        }

        public void Delete(Address findAddress)
        {
            Address address = addressBusiness.Get(findAddress);
            if (address != null)
            {
                addressBusiness.Delete(findAddress);
            }
            else
            {
                throw new ArgumentException("Address not found.");
            }
        }

        public Address Get(Address findAddress)
        {

            Address address = addressBusiness.Get(findAddress);
            if (address != null)
            {
                return address;
            }
            else
            {
                throw new ArgumentException("Address not found");
            }
        }

        public List<Address> ListAll()
        {
            var addresss = addressBusiness.GetAll();
            if (addresss.Count > 0)
            {
                return addresss;
            }
            else
            {
                throw new ArgumentException("The list is empty.");
            }
        }

        public void Update(Address findAddress)
        {

            Address address = addressBusiness.Get(findAddress);
            if (address != null)
            {

                addressBusiness.Update(findAddress);
            }
            else
            {
                throw new ArgumentException("Address not found.");
            }
        }
    }
}
