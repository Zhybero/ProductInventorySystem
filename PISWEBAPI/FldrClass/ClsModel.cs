namespace PISWEBAPI.FldrClass
{
    public class ModelProduct
    {
        public string? Name { get; set; } 
        public string? Code { get; set; }
    }
    public class ModeltblProductEntry
    {
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDesc { get; set; }
        public string? PTypeCode { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
    }
    public class ModelDelete
    {
        public List<string>? Code { get; set; }
    }
}
