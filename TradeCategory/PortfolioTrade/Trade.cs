using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.PortfolioTrade;

namespace TradeCategory.PortfolioTrades
{
    class Trade : ITrade
    {
        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public bool IsPoliticallyExposed { get; set; } // for second question
    }
}
