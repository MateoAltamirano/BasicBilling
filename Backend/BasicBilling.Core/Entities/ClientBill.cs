using System;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace BasicBilling.Core.Entities
{
	public class ClientBill
	{
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BillId { get; set; }
        public BillStatus Status { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Bill? Bill { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BillStatus
    {
        Pending,
        Paid
    }
}

