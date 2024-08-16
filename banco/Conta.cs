using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancário.banco
{
    public abstract class Conta
    {
        protected string Owner { get; set; } = string.Empty;
        protected decimal Balance { get; set; }

        public void Deposit(decimal value)
        {
            Balance += value;
            GetBalance();
        }

        public string GetBalance(){
            return $"Seu saldo é {Balance}";
        }

        public abstract bool Withdraw(decimal value);
    }
}