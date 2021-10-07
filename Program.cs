using System;
using System.Globalization;
using System.Collections.Generic;
using Installment.Entities;
using Installment.Entities.Exceptions;

namespace Installment
{
	public class Program
	{
		public static void Main(string[] args)
		{
			PaymentManager manager = new PaymentManager();
			bool sys = true;
			int id = 001;
			while(sys == true)
			{
				Console.WriteLine("Options:\n1-Registrer a new costumer\n2-Add a new debt");
				Console.WriteLine("3-Add payment\n4-List of clients\n5-Logout");

				int option = int.Parse(Console.ReadLine());
			
				switch (option)
				{
					case 1:
					{
						manager.AddClient(id);
						id++;
						break;
					}					
					case 2:
					{
						manager.AddInstallment();
						break;
					}
					case 3:
					{
						manager.RegisterPayment();
						break;
					}
					case 4:
					{
						manager.PrintList();
						Console.Clear();
						break;
					}
					case 5:
					{
						Console.Clear();
						Console.WriteLine("\n\nBye");
						Console.ReadLine();	
						Console.Clear();
						sys = false;
						break;
					}
					default:
					{
						throw new DomainException("This option in not valid\n");
					}
					
				}
			}
		}
	}
}					