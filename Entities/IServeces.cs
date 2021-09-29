using System;
using System.Collections.Generic;

namespace Installment.Entities
{
	public interface IServices
	{
		List<Client> Clients {get;}

		void AddClient();
	
		void AddInstallment();
	
		void RegisterPayment();
	}
}
