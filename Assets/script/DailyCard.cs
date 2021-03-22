using System.Collections.Generic;
using Newtonsoft.Json;

public class DailyProduct
{
	public int type { get; set; }
	public int num { get; set; }
	public int isPurchased { get; set; }
	public int subType { get; set;}
	
	public int costGold { get; set;}
}

public class DailyData
{
	public List<DailyProduct> dailyProduct { get; set; }
	public int dailyProductCountDown { get; set; }
}
