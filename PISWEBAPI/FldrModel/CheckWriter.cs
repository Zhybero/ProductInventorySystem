namespace PISWEBAPI.FldrModel
{
    public class ModeltblCheckWriterSetup
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public int XDate { get; set; }
        public int YDate { get; set; }
        public int FontDate { get; set; }
        public int XCustName { get; set; }
        public int YCustName { get; set; }
        public int FontCustName { get; set; }
        public int XCAmount { get; set; }
        public int FontCAmt { get; set; }
        public int XAmtInWord { get; set; }
        public int YAmtInWord { get; set; }
        public int FontAmtWord { get; set; }
        public int XCompDoc { get; set; }
        public int YCompDoc { get; set; }
        public bool BoxDate { get; set; }
        public int YCAmount { get; set; }
        public int FontCompDoc { get; set; }
    }

    public class ModelViewCheckWriter
    {
        public string CheckNo { get; set; }
        public double CAmount { get; set; }
        public DateTime TDate { get; set; }
        public string CustName { get; set; }
        public string Voucher { get; set; }
        public string DocNum { get; set; }
        public double Credit { get; set; }
        public string AcctNo { get; set; }
        public string CNCode { get; set; }
        public bool Void { get; set; }
        public string BankActEntry { get; set; }
    }

    public class Users
    {
        public string UserCode { get; set; }
        public string PWord { get; set; }
        public string GroupCode { get; set; }
        public string UserName { get; set; }
        public string UserName1 { get; set; }
        public string CNCode { get; set; }
        public bool Active { get; set; }
        public string CompleteName { get; set; }
    }

    public class CompanyName
    {
        public string CNCode { get; set; }
        public string CName { get; set; }
        public string CName1 { get; set; }
        public string CAddress { get; set; }
    }

    public class BalanceSheet
    {
        public string FCDesc { get; set; }
        public string FCSort { get; set; }
        public string TitleAcct { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public decimal SumTotAmt { get; set; }
        public decimal SumTotLOAmt { get; set; }
    }

    public class ViewBookCV
    {
        public string? DocNum { get; set; }
        public string? Voucher { get; set; }
        public string? UserName { get; set; }
        public DateTime? TDate { get; set; }
        public string? Reference { get; set; }
        public string? Remarks { get; set; }
        public int? Term { get; set; }
        public string? CheckNo { get; set; }
        public double? CAmount { get; set; }
        public string? Refer { get; set; }
        public double? Debit { get; set; }
        public double? Credit { get; set; }
        public string? PA { get; set; }
        public int? RowNum { get; set; }
        public string? CustName { get; set; }
        public string? CNCode { get; set; }
        public string? AT { get; set; }
        public string? ActRemarks { get; set; }
        public string? SIT { get; set; } 
        public string? ControlNo { get; set; }
        public string? IC { get; set; }
        public string? CVNo { get; set; }
    }
}
