using System;
using System.Globalization;
using System.Collections.Generic;
using Installment.Entities.Exceptions;

namespace Installment.Entities
{
	public class Client : IComparable
	{
		public string ClientName {get; set;}
		public int Id {get; private set;}
		public List<InstallmentsPay> Installments{get; set;} = new List<InstallmentsPay>();
	
		public Client(){}
	
		public Client(int id, string name)
		{
			ClientName = name;
			Id = id; 
		}
	
		public Client(int id, string name, InstallmentsPay installment)
		{
			ClientName = name;
			Id = id;
			Installments.Add(installment);
		}
		
		public double GetTotalInstallments()
		{
			double total = 0;
			foreach(InstallmentsPay pay in Installments)
			{
				if(pay.State == false)
				{
					total += pay.Value;
				}
			}
			return total;
		}

		//Ordenar a lista pelo nome do cliente
		public int CompareTo(object obj)
		{
			Client other = obj as Client;
			return ClientName.CompareTo(other.ClientName);
		}
		//Adicionar uma nova parcela
		public void AddNewInst(InstallmentsPay installments)
		{
			Installments.Add(installments);
		}
		//exibe a lista de parcelas pagas ou não, e caso a lista esteja vazia, laça uma exeção.
		public void ListToPay()
		{
			if(Installments.Count == 0)
			{
				throw new DomainException("This client don't have iny installments.");
			}


			InstallmentsPay[] pay = Installments.ToArray();
			int aux = pay.Length;
			int cont = 1;

			for(int i = 0; i < aux; i++)
			{
				Console.WriteLine(cont + "-Installment of " + pay[i].Date.ToString("dd/MM/yyyy") + ", Value: "  + pay[i].Value.ToString("F2", CultureInfo.InvariantCulture));
				if(pay[i].State)
				{
					Console.WriteLine("   It's payed");	
				}
				else
				{
					Console.WriteLine("  Need to be payed");
				}
				cont++;

			}	
			Console.Write("\nSelect  installment to pay: ");
			int chose = int.Parse(Console.ReadLine());

			chose = (chose - 1);
			bool state = pay[chose].CheckPay();

			if(state)
			{
				Console.WriteLine("The installment payed.");
				Console.ReadLine();
				return;
			}
			else
			{
				Console.WriteLine("This installment has already been payed.");
				Console.ReadLine();
				return;
			}				
			
		}
	}
}