
using SistemaBancário.banco;

bool IsRunning = true;

while (IsRunning)
{
  Console.WriteLine("Seja bem-vindo ao seu banco!");

  Console.WriteLine("Qual o seu nome?");
  string name = Console.ReadLine()!;

  TelaInicial:
    Console.WriteLine($"Olá {name} O que deseja fazer? (Digite apenas o número)");

    Console.WriteLine("1. Acessar Conta Corrente");
    Console.WriteLine("2. Acessar Conta Poupança");
    Console.WriteLine("3. Sair");

  int choice = int.Parse(Console.ReadLine()!);

  switch (choice)
  {
    case 1:
      var contaCorrente = new ContaCorrente(name);

      TelaCorrente:
        Console.WriteLine("O que deseja realizar?");
        Console.WriteLine("1. Depositar");
        Console.WriteLine("2. Sacar");
        Console.WriteLine("3. Consultar saldo");
        Console.WriteLine("4. Registrar boleto");
        Console.WriteLine("5. Contar boletos");
        Console.WriteLine("6. Ver todos os boletos");
        Console.WriteLine("7. Consultar um boleto");
        Console.WriteLine("8. Pagar boleto");
        Console.WriteLine("9. Voltar");

      int subChoiceCorrente = int.Parse(Console.ReadLine()!);

      switch (subChoiceCorrente)
      {
        case 1:
          Console.WriteLine("Quanto deseja depositar?");
          decimal deposit = decimal.Parse(Console.ReadLine()!);
          contaCorrente.Deposit(deposit);

          Console.WriteLine(contaCorrente.GetBalance());
          goto TelaCorrente;
        
        case 2:
          Console.WriteLine("Quanto deseja sacar?");
          decimal withdraw = decimal.Parse(Console.ReadLine()!);
          contaCorrente.Withdraw(withdraw);

          Console.WriteLine(contaCorrente.GetBalance());
          goto TelaCorrente;
        
        case 3:
          Console.WriteLine(contaCorrente.GetBalance());
          goto TelaCorrente;
        
        case 4:
          Console.WriteLine("Como deseja identificar o boleto?");
          string identifier = Console.ReadLine()!;

          Console.WriteLine("Qual valor do boleto?");
          decimal value = decimal.Parse(Console.ReadLine()!);

          Console.WriteLine("Qual data de vencimento do boleto?");
          DateTime endDate = DateTime.Parse(Console.ReadLine()!);

          contaCorrente.RegisterTicket(identifier, name, value, endDate); 
          goto TelaCorrente;

        case 5:
          Console.WriteLine(contaCorrente.CountTicket());
          goto TelaCorrente;

        case 6:
          List<Boleto> allTickets = contaCorrente.GetAllTickets();
          foreach (var ticket in allTickets)
          {
            Console.WriteLine(ticket.ToString());
          }
          goto TelaCorrente;

        case 7:
          Console.WriteLine("Qual boleto deseja consultar?");
          int index = int.Parse(Console.ReadLine()!) - 1;
          Console.WriteLine(contaCorrente.GetTicketInformation(index));
          goto TelaCorrente;

        case 8:
          Console.WriteLine("Qual boleto deseja pagar?");
          int indexPay = int.Parse(Console.ReadLine()!) - 1;
          contaCorrente.PayTicket(indexPay);
          goto TelaCorrente;

        case 9:
          goto TelaInicial;
        
        default:
          goto TelaInicial;
      }
    
    case 2:
      var poupança = new ContaPoupanca(name);

      TelaPoupanca:
        Console.WriteLine("O que deseja realizar?");
        Console.WriteLine("1. Depositar");
        Console.WriteLine("2. Sacar");
        Console.WriteLine("3. Consultar saldo");
        Console.WriteLine("4. Ver rendimentos");
        Console.WriteLine("5. Voltar");

      int subChoicePoupanca = int.Parse(Console.ReadLine()!);

      switch (subChoicePoupanca)
      {
        case 1:
          Console.WriteLine("Quanto deseja depositar?");
          decimal deposit = decimal.Parse(Console.ReadLine()!);
          poupança.Deposit(deposit);
          Console.WriteLine(poupança.GetBalance());
          goto TelaPoupanca;

        case 2:
          Console.WriteLine("Quanto deseja sacar?");
          decimal withdraw = decimal.Parse(Console.ReadLine()!);
          poupança.Withdraw(withdraw);
          Console.WriteLine(poupança.GetBalance());
          goto TelaPoupanca;

        case 3:
          Console.WriteLine(poupança.GetBalance());
          goto TelaPoupanca;

        case 4:
          Console.WriteLine(poupança.GetIncomeInformation());
          goto TelaPoupanca;

        case 5:
          goto TelaInicial;

        default:
          goto TelaInicial;
      }

    case 3:
      Console.WriteLine("Até logo!");
      IsRunning = false;
      break;
    default:
      Console.WriteLine("Até logo!");
      IsRunning = false;
      break;
  }
}