using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancário.banco
{
    public sealed class ContaPoupanca : Conta
    {
        public decimal Income { get; set; } = 6.25M;

        public ContaPoupanca(string owner)
        {
            Owner = owner;
            Balance = 0;
        }

        public string GetIncomeInformation(){
            decimal totalIncomeByYear = Balance * (Income / 100);
            
            return $"Seu saldo é {Balance} e seu rendimento é {Income}% ao ano." + 
            $"\n\n Após 1 ano terá rendido {totalIncomeByYear} reais de acordo com seu saldo" + 
            $"\n Após 2 anos terá rendido {totalIncomeByYear * 2}reais de acordo com seu saldo" +
            $"\n Após 3 anos terá rendido {totalIncomeByYear * 3}reais de acordo com seu saldo" +
            $"\n Após 4 anos terá rendido {totalIncomeByYear * 4} reais de acordo com seu saldo";
        }

        public override bool Withdraw(decimal value)
        {
            if (Balance >= value || value != 0)
            {
                Balance -= value;
                GetBalance();
                return true;
            }
            return false;
        }
    }
}