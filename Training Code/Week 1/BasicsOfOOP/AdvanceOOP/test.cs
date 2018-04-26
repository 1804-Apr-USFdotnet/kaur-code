using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceOOP
{
    class test : IInsurance, ICredit
    {
        public string ccNum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int cvv { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Cover()
        {
            throw new NotImplementedException();
        }

        public decimal CurrentBalance(decimal expenditure, decimal limit)
        {
            throw new NotImplementedException();
        }
    }
}
