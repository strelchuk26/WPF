namespace ClassLibrary
{
	[Serializable]
	public class Order
	{
		public string ClientFullName { get; set; }
		public string ClientPhoneNumber { get; set; }
		public string ClientAddress { get; set; }
		public string PizzaName { get; set; }
		public int PizzaCount { get; set; }
	}
}