using System;
using System.Globalization;
using System.Collections.Generic;

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
			//Installment.Add(null);
		}
	
		public Client(int id, string name, InstallmentsPay installment)
		{
			ClientName = name;
			Id = id;
			Installments.Add(installment);
		}

		public override string ToString()
		{
			return "Client name: " + ClientName + ", Id: " + Id;
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

		public int CompareTo(object obj)
		{
			Client other = obj as Client;
			return ClientName.CompareTo(other.ClientName);
		}

		public void AddNewInst(InstallmentsPay installments)
		{
			Installments.Add(installments);
		}
		//criar um metodo para exbir a lista de parcelas aqui....?

		public void ListToPay()
		{
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