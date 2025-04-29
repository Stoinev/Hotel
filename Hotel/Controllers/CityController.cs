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
    public class CityController : IController<City>
    {
        private ICRUD<City> cityBusiness = new CityBusiness();
        public CityController()
        {

        }
        public CityController(ICRUD<City> cityBusiness)
        {
            this.cityBusiness = cityBusiness;
        }

        public void Add(City newCity)
        {

            City city = cityBusiness.Get(newCity);
            if (city != null)
            {
                throw new ArgumentException("City with this ID exists.");
            }
            //TODO manager
            cityBusiness.Add(newCity);
        }

        public void Delete(City findCity)
        {
            City city = cityBusiness.Get(findCity);
            if (city != null)
            {
                cityBusiness.Delete(findCity);
            }
            else
            {
                throw new ArgumentException("City not found.");
            }
        }
        public City Get(City findCity)
        {

            City city = cityBusiness.Get(findCity);
            if (city != null)
            {
                return city;
            }
            else
            {
                throw new ArgumentException("City not found");
            }
        }


        public void Update(City findCity)
        {

            City city = cityBusiness.Get(findCity);
            if (city != null)
            {
                cityBusiness.Update(findCity);
            }
            else
            {
                throw new ArgumentException("City not found.");
            }
        }

        public List<City> ListAll()
        {

            var citys = cityBusiness.GetAll();
            if (citys.Count > 0)
            {
                return citys;
            }
            else
            {
                throw new ArgumentException("The list is empty.");
            }
        }
    }
}
