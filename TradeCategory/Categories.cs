using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.PortfolioTrade;
using TradeCategory.Risks;

namespace TradeCategory
{
    class Categories
    {
        private List<ITrade> listPortifolio;
        
        public Categories(List<ITrade> listPortifolio)
        {
            this.listPortifolio = listPortifolio;
        }

        public List<string> GetCategories(DateTime CurrencyData)
        {
            List<string> listCategories = new List<string>();
            Risk risk = new Risk();

            foreach (var trade in listPortifolio)
            {
                listCategories.Add(risk.CalculateRisk(trade, CurrencyData));
            }
            return listCategories;
        }
   
    }
}
