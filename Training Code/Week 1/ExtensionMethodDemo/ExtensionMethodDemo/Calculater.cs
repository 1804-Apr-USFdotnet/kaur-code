using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodDemo
{
    public class Calculater
    {
        public int Add(params int[] data)
        {
            int temp = 0;
            foreach (var item in data)
            {
                temp += item;
            }
            return temp;
        }
    }
}
