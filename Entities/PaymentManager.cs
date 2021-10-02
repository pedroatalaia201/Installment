using System;
using System.Collections.Generic;
using System.Globalization;

namespace Installment.Entities
{
	public class PaymentManager : IServices 
	{
		public List<Client> Clients{get; set;} = new List<Client>();
		
	
		public void AddClient(int id)
		{
			Console.Clear();
			
			Console.WriteLine("Write the name of the client:");
			string name = Console.ReadLine();
			Console.WriteLine("There will be a installmet for this client?(y/n)");
			char op = char.Parse(Console.ReadLine());

			

			if(op == 'y')
			{
				Console.Write("Data of the installment(dd/mm/yyyy): ");
				DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
				Console.Write("The value of the installment: ");
				double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
			
				InstallmentsPay inst = new InstallmentsPay(date, value);
					
			 	Clients.Add(new Client(id, name, inst));
				Console.WriteLine("\n\nThe client is registred:");
				Console.WriteLine("Client name: " + name + ", Id: " + id);
				Console.WriteLine("With a installment of U$: " + value.ToString("F2", CultureInfo.InvariantCulture));
				Console.WriteLine("press Enter to continue...");

				id++;
			}
			else
			{
				Clients.Add(new Client(id, name));
				Console.WriteLine("\n\nThe client is registred:");
				Console.WriteLine("Client name: " + name + ", Id: " + id);
				Console.WriteLine("press Enter to continue...");
			}
		
			Console.ReadLine();
			Console.Clear();
			return;
		}
	//need to be optimazed....
		public void AddInstallment()
		{
			Console.Clear();
			int mess = 0;

			Console.WriteLine("Write the data of the client");
			Console.Write("Name: ");
			string name = Console.ReadLine();
			Console.Write("The id of the client: ");
			int idSearch = int.Parse(Console.ReadLine());
			Console.Write("Define the value of this new installment U$: ");
			double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
			Console.Write("The date os this new installment(dd/mm/yyyy): ");
			DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

			foreach(Client client in Clients)
			{
				if(client.ClientName == name && client.Id == idSearch)
				{
					client.AddNewInst(new InstallmentsPay(date, value));
				}
				else
				{
					mess++;	
				}
			}

			if(mess == Clients.Capacity)
			{
				Console.WriteLine("The client was not found");
				Console.ReadLine();
				return;
			}

			Console.WriteLine("That new debt was registred");
			Console.WriteLine("press enter to continue...");
			Console.ReadLine();
			Console.Clear();
			return;
		}
	//não bastar ter só o código do cliente e o nome, tem de ter o valor do título e mais um atributo
	//para poder identificar o título a ser pago....
		public void RegisterPayment()
		{
			Console.Clear();
			Console.WriteLine("Enter the name of the client: ");
			string name = Console.ReadLine();
			Console.Write("The Id of the client: ");
			int id = int.Parse(Console.ReadLine());

			List<Client> clientDebt = new List<Client>();

			foreach(Client client in Clients)
			{
				if(client.ClientName == name && client.Id == id)
				{
					clientDebt.Add(client);
				}
			}

			Console.WriteLine("Selec the installment to be payed: ");
			for(int i = 0; i < clientDebt.Lenght(); i++)
			{
				i + 1;
				Console.WriteLine(i + "-Client: " + clientDebt.ClientName + ", Id: " + clientDebt.Id +
				", Installment from " + clientDebt.Installments.Date.ToString("dd/MM/yyyy")) + ", value U$"
				+ clientDebt.Installments.Value.ToString("F2", CultureInfo.InvariantCulture);
			}

			Console.ReadLine();
		}
	
		public void PrintList()
		{
			Console.Clear();

			Clients.Sort();
			foreach(Client client in Clients)
			{
				Console.WriteLine("Client: " + client.ClientName + ", Id: " + client.Id);
				Console.WriteLine("With a total of intallments U$: " + client.GetTotalInstallments().ToString("F2", CultureInfo.InvariantCulture));
				Console.WriteLine();
			}
			Console.WriteLine("\npress Enter to exit...");
			Console.ReadLine();
		}
	
	}
}