using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancário.banco
{
    public class Boleto
    {
        public string Identifier {get; set;} = string.Empty;
        public decimal fees {get; private set;}
        public string Owner { get; set; }
        public decimal Value { get; set; }
        public DateTime EndDate { get; set; }
        public bool Paid { get; private set; }

        public Boleto(string identifier, string owner, decimal value, DateTime endDate)
        {
            Identifier = identifier;
            Owner = owner;
            EndDate = endDate;
            Value = value;
            fees = 0.02M;
            Paid = false;
        }

        public bool Pay(decimal balance, DateTime endDate)
        {
            if (endDate <= DateTime.Today)
            {
                Value += Value * fees;
                if (Value > balance)
                {
                    return false;
                }

                SetPaid();
                return Paid;
            }

            if (Value > balance)
            {
                return false;
            }
            
            SetPaid();
            return Paid;
        }

        private void SetPaid(){
            Paid = true;
        }

        public override string ToString(){
            return $"Identificador: {Identifier}\n" +
                   $"Dono: {Owner}\n" +
                   $"Valor: {Value}\n" +
                   $"Data de vencimento: {EndDate}\n" +
                   $"Status: {Paid}";
        }
    }
}