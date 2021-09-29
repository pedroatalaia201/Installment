using System;

namespace Installment.Entities
{
	public class Installments
	{
		public DateTime Date {get;set;}
		public double Value {get; private set;}
		public bool State {get; private set;}
	
		public Installments(){}
	
		public Installments(DateTime date, double value)
		{
			Date = date;
			Value = value;
			State = false;
		}
	}
}
