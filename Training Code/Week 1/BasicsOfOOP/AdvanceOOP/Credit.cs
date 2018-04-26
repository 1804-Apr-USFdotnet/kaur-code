using System;

namespace AdvanceOOP
{
    class Credit : test,IAmex, IBoa//multiple inheritance
    {
        public string ccNum { get { return ccNum; }
            set { ccNum = value; } }
        public int cvv { get { return cvv; }
            set { cvv = value; }
        }
        public decimal CurrentBalance(decimal expenditure, decimal limit)
        {
            return limit - expenditure;
        }
        string IAmex.Offer(int creditScore, int salary)
        {
            if (salary > 2000 && creditScore > 600 && creditScore < 750)
            {
                return "15%";
            }
            else if (salary > 4000 && creditScore > 750)
            { return "25%"; }
            else
                return "Not Eligible";
        }
        string IBoa.Offer(int creditScore, int salary)
        {
            if (salary > 1000 && creditScore > 500 && creditScore < 700)
            {
                return "10%";
            }
            else if (salary > 3000 && creditScore > 750)
            {
                return "25%";
            }
            else
                return "Not Eligible";
        }
    }
}
