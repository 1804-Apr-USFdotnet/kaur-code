using System;

namespace AdvanceOOP
{
    interface ICredit
    {
      string ccNum { get; set; }
      int cvv { get; set; }
      decimal CurrentBalance(decimal expenditure, decimal limit);
    }
}
