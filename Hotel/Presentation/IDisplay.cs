using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Presentation
{
    public interface IDisplay
    {
        void ShowMenu();
        void Input();
        void Add();
        void Delete();
        void Fetch();
        void Update();
        void ListAll();
    }
}
