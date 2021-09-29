using System;
using System.Collections.Generic;
using System.Globalization;

namespace Installment.Entities
{
	public class PaymentManager : IServices 
	{
		public List<Client> Clients{get; private set;}
	
		public void AddClient()
		{
			Console.Clear();
			Client client = new Client();

			Console.WriteLine("Wrtie the name of the client:");
			string name = Console.ReadLine();
		
			Console.WriteLine("There will be a installmet for this client?(y/n)");
			char op = char.Parse(Console.ReadLine());
			Random rand = new Random();
			int id = rand.Next();
		
			if(op == 'y')
			{
				Console.Write("Data of the installment(dd/mm/yyyy): ");
				DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
				Console.Write("The value of the installment: ");
				double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
			
				Installments inst = new Installments(date, value);
					
				//client = new Client(id, name, inst);
			 	Clients.Add(new Client(id, name, inst));
				Console.WriteLine("\n\nThe client is registred\nPress enter to continue");
			}
			else
			{
				Clients.Add(new Client(id, name));
				Console.WriteLine("\n\nThe client is registred\nPress enter to continue");
			}
		
			Console.ReadLine();
			Console.Clear();
			return;
		}
	
		public void AddInstallment()
		{
			
		}
	
		public void RegisterPayment()
		{
		
		}
	
		public void PrintList()
		{
			Console.Clear();
			foreach(Client client in Clients)
			{
				Console.WriteLine("Client: " + client.ClientName + ", Id: " + client.Id);
			}
		}
	
	}
}