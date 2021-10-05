using System;

namespace Installment.Entities
{
	public class InstallmentsPay
	{
		public DateTime Date {get;set;}
		public double Value {get; private set;}
		public bool State {get; private set;}
	
		public InstallmentsPay(){}
	
		public InstallmentsPay(DateTime date, double value)
		{
			Date = date;
			Value = value;
			State = false;
		}

		public bool CheckPay()
		{
			if(State == true)
			{				
				return false;
			}
			else
			{
				GetPayed();
				return true;
			}
		}

		public void GetPayed()
		{
			State = true;
		}
	}
}
