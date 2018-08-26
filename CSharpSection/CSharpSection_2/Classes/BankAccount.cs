using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSection_2.Classes
{
    public class BankAccount
    {
        private float _balance;
        // property to secure balance
        public float Balance
        {
            get { return _balance; }
            private set
            {
                if (value >= 0)
                    _balance = value;
                else
                    _balance = 0;
            }
        }
        private string _owner;


        public BankAccount(float balance, string owner)
        {
            this.Balance = balance;
            this._owner = owner;
        }
        public float addBalance(float balanceToBeAdded)
        {
            Balance = _balance + balanceToBeAdded;
            return Balance;
        }
        public float addBalance(float balanceToBeAdded, bool balanceCanBeNegative)
        {
            if (balanceCanBeNegative)
                _balance = _balance + balanceToBeAdded;
            else
                Balance = _balance + balanceToBeAdded;
            return Balance;
        }
    }

    public class ChildBankAccount : BankAccount
    {
        public string Parent { get; set; }

        public ChildBankAccount(float balance, string owner, string parent) : base(balance, owner)
        {
            Parent = parent;


        }


    }
}
