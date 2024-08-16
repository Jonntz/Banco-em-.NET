using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancário.banco
{
    public class ContaCorrente : Conta
    {
        private decimal WithdrawRate { get; set; } = 0.05M;
        private decimal CreditLimit { get; set; } = 100;
        private List<Boleto> Tickets { get; set; }

        public ContaCorrente(string owner)
        {
            Owner = owner;
            Balance = 0;
            Tickets = new List<Boleto>();
        }

        public override bool Withdraw(decimal value)
        {
            decimal totalWithdraw = value + WithdrawRate;
            if (Balance + CreditLimit >= totalWithdraw || value != 0)
            {
                Balance -= totalWithdraw;
                GetBalance();
                return true;
            }
            return false;
        }

        public void RegisterTicket(string identifier, string owner, decimal value, DateTime endDate){
            var ticket = new Boleto(identifier, owner, value, endDate);
            Tickets.Add(ticket);
            Console.WriteLine("Boleto registrado com sucesso!");
        }

        public string CountTicket()
        {
            return $"Boletos registrados: {Tickets.Count}";
        }

        public List<Boleto> GetAllTickets()
        {
            List<Boleto> tickets = Tickets;
            return tickets;            
        }

        public string GetTicketInformation(int index)
        {
            if (index < 0 || index >= Tickets.Count)
            {
                return "Ticket não encontrado";
            }
            
            var ticket = Tickets[index].ToString();
            return ticket.ToString();
        }

        public bool PayTicket(int index)
        {
            if (index < 0 || index >= Tickets.Count)
            {
                return false;
            }

            var ticket = Tickets[index];

            Console.WriteLine("Boleto pago com sucesso!");
            return ticket.Pay(Balance, ticket.EndDate);  
        }
    }
}