public class Client
{
	public string ClientName {get; set;}
	public int Id {get; private set;}
	public List<Installments> Installment{get; set;}
	
	public Client(){}
	
	public Client(int id, string name)
	{
		ClientName = name;
		Id = id; 
		//Installment.Add(null);
	}
	
	public Client(int id, string name, Installments installment)
	{
		ClientName = name;
		Id = id;
		Installment.Add(installment);
	}
	
	
}