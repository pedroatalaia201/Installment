using System;
using System.Collections.Generic;
using System.Globalization;

namespace Installment.Entities
{
	public class PaymentManager : IServices 
	{
		public List<Client> Clients{get; set;} = new List<Client>();
		
	
		public void AddClient()
		{
			Console.Clear();
			
			Console.WriteLine("Write the name of the client:");
			string name = Console.ReadLine();
			Console.WriteLine("There will be a installmet for this client?(y/n)");
			char op = char.Parse(Console.ReadLine());

			int id

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
	
		public void AddInstallment()
		{
			int mess = 0;

			Console.WriteLine("Write the data of the client");
			Console.Write("Name: ");
			string name = Console.ReadLine();
			Console.Write("The id of the client: ");
			int idSearch = int.Parse(Console.ReadLine());
			Console.Write("Define the value of this new installment U$: ");
			double value = double.Parse(Console.ReadLine());
			Console.Write("The date os this new installment(dd/mm/yyyy): ");
			DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

			foreach(Client client in Clients)
			{
				if(client.ClientName == name && client.Id == idSearch)
				{
					Console.WriteLine("Well, I guess it works...");
				}
				else
				{
					mess++;	
				}
			}

			if(mess == Clients.Capacity)
			{
				Console.WriteLine("The client was not found");
			}
			
		}
	
		public void RegisterPayment()
		{
		
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