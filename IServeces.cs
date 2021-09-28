public interface IServices
{
	List<Client> Clients {get;}
	
	void AddClient();
	
	void AddInstallment();
	
	void RegisterPayment();
}