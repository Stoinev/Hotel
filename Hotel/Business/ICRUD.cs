using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business
{
    public interface ICRUD<T>
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T Get(T item);
        List<T> GetAll();
    }
}
