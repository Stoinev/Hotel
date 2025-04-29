using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Presentation
{
    public class Dislpay
    {
        private int closeOperationId = 7;
        public Dislpay()
        {
            Input();
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Addresses");
            Console.WriteLine("2. Cities");
            Console.WriteLine("3. Clients");
            Console.WriteLine("4. Rooms");
            Console.WriteLine("5. ------");
            Console.WriteLine("6. ------");
            Console.WriteLine("7. Exit");
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
                        AddressDisplay d = new AddressDisplay();
                        break;
                    case 2:
                        CityDisplay st = new CityDisplay();
                        break;
                    case 3:
                        ClientDisplay m = new ClientDisplay();
                        break;
                    case 4:
                        RoomDisplay hm = new RoomDisplay();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;

                }
            } while (operation != closeOperationId);
        }
    }
}
