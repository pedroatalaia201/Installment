using System;
using System.Collections.Generic;
using System.Globalization;
using Installment.Entities.Exceptions;

namespace Installment.Entities
{
	public class PaymentManager : IServices 
	{
		public List<Client> Clients{get; set;} = new List<Client>();
		
		//adiciona um novo cliente na lista
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
			}
			if(op == 'n')
			{
				Clients.Add(new Client(id, name));
				Console.WriteLine("\n\nThe client is registred:");
				Console.WriteLine("Client name: " + name + ", Id: " + id);
				Console.WriteLine("press Enter to continue...");
			} 

			else
			{
				throw new DomainException("This option in not valid\n");
			}
				
			Console.ReadLine();
			Console.Clear();
		}
		//adiciona uma nova parcela:
		public void AddInstallment()
		{
			Console.Clear();
			int miss = 0;

			Console.WriteLine("Write the data of the client");
			Console.Write("Name: ");
			string name = Console.ReadLine();
			Console.Write("The id of the client: ");
			int idSearch = int.Parse(Console.ReadLine());

			foreach(Client client in Clients)
			{
				if(client.ClientName == name && client.Id == idSearch)
				{
					Console.Write("Define the value of this new installment U$: ");
					double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
					Console.Write("The date os this new installment(dd/mm/yyyy): ");
					DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
					client.AddNewInst(new InstallmentsPay(date, value));
				}
				else
				{
					miss += ContMiss();
					if(miss == Clients.Count)
					{
						throw new DomainException("Client was not found...");
					}
				}
			}

			Console.WriteLine("That new debt was registred");
			Console.WriteLine("press enter to continue...");
			Console.ReadLine();
			Console.Clear();
		}
		//registra os pagamentos das parcelas
		public void RegisterPayment()
		{
			Console.Clear();
			Console.WriteLine("Enter the name of the client: ");
			string name = Console.ReadLine();
			Console.Write("The Id of the client: ");
			int id = int.Parse(Console.ReadLine());

			int count = 0;

			foreach(Client client in Clients)
			{
				if(client.ClientName == name && client.Id == id)
				{
					Console.Clear();
					Console.WriteLine("Installments of the client " + name + ", Id: " + id);
					client.ListToPay();
					Console.Clear();
					return;
				}
				else
				{
					count += ContMiss();
					if(count == Clients.Count)
					{
						throw new DomainException("Client not found...");
					}
				}	
			}

			Console.ReadLine();
		}
		//auxiliar
		private int ContMiss()
		{
			return 1;
		}
		//exibe uma lista com o os clientes e o total de parcelas de cada um.
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