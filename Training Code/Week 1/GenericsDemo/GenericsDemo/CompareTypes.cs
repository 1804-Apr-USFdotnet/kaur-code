using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public class CompareTypes
    {
        public bool CompareTwo(object data1, object data2)
        // public bool CompareTwo<T>(T data1, T data2)
        {
            return data1.Equals(data2);
        }
    }
}
