using System;
using System.Collections.Generic;

namespace Installment.Entities
{
	public class Client
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
				total += pay.Value;
			}
			return total;
		}
	}
}