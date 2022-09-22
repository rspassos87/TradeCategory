using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.PortfolioTrade;
using static TradeCategory.Risks.Enum;

namespace TradeCategory.Risks
{
    class Risk
    {  
        public string CalculateRisk(ITrade trade, DateTime CurrencyData)
        {
            Dictionary<bool, string> ret = new Dictionary<bool, string>();

            #region EXPIRED
            int days = trade.NextPaymentDate.Subtract(CurrencyData).Days;
            if (days < 30)
            {
                return TypeRisk.EXPIRED.ToString();
            }
            #endregion

            #region HIGHRISK
            if (trade.Value > 1000000 && trade.ClientSector.Equals(TypeSector.Private.ToString()))
            {
                return TypeRisk.HIGHRISK.ToString();
            }
            #endregion

            #region MEDIUMRISK
            if (trade.Value > 1000000 && trade.ClientSector.Equals(TypeSector.Public.ToString()))
            {
                return TypeRisk.MEDIUMRISK.ToString();
            }
            #endregion

            #region PEP - for second questionn
            /*if (trade.IsPoliticallyExposed)
                return TypeRisk.PEP.ToString();
           */
            #endregion

            return "Not found risk for TRADE:" +trade.Value + ", "+ trade.ClientSector+", "+ trade.NextPaymentDate;
        }
    }
}
