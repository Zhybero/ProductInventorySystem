namespace PISWEBAPI.FldrModel
{
	public class FilModel
	{
	}

	public class AcctTitle
	{
		public string? AcctNo { get; set; }
		public string? TitleAcct { get; set; }
		public string? FSClass { get; set; }
		public string? FCCode { get; set; }
		public string? SCCode { get; set; }
		public string? NormalBal { get; set; }
		public string? UsageCode { get; set; }
		public string? SearchKey { get; set; }
	}

	public class FSList
	{
		public string Code { get; set; }
		public string Description { get; set; }

	}
	public class FCList
	{
		public string FCCode { get; set; }
		public string FCDesc { get; set; }
	}

	public class SCList
	{
		public string SCCode { get; set; }
		public string Description { get; set; }
	}
	public class NormalBal
	{
		public string Code { get; set; }
		public string Description { get; set; }
	}
	public class ViewUsageCode
	{
		public string UsageCode { get; set; }
		public string UsageDesc { get; set; }
	}
}
