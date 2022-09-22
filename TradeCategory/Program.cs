using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TradeCategory.PortfolioTrade;
using TradeCategory.PortfolioTrades;
using TradeCategory.Risks;

namespace TradeCategory
{
    class Program
    {
        static void Main(string[] args)
        {

            CultureInfo enUS = new CultureInfo("en-US");
            #region IMPUT
            DateTime date = DateTime.ParseExact("09/22/2022", "MM/dd/yyyy", enUS, DateTimeStyles.None); //Line 1
            int tradeCount; ;

            Trade t1 = new Trade { Value = 2000000, ClientSector = "Private", NextPaymentDate = DateTime.ParseExact("12/29/2025", "MM/dd/yyyy", enUS, DateTimeStyles.None) };
            Trade t2 = new Trade { Value = 400000, ClientSector = "Public", NextPaymentDate = DateTime.ParseExact("07/01/2020", "MM/dd/yyyy", enUS, DateTimeStyles.None) };
            Trade t3 = new Trade { Value = 5000000, ClientSector = "Public", NextPaymentDate = DateTime.ParseExact("01/02/2024", "MM/dd/yyyy", enUS, DateTimeStyles.None) };
            Trade t4 = new Trade { Value = 3000000, ClientSector = "Public", NextPaymentDate = DateTime.ParseExact("10/26/2023", "MM/dd/yyyy", enUS, DateTimeStyles.None) };
            List<ITrade> listPortifolio = new List<ITrade>() { t1, t2, t3, t4 };
            tradeCount = listPortifolio.ToList().Count();

            #endregion

            Categories categories = new Categories(listPortifolio);
            List<string> tradeCategories = categories.GetCategories(date);

            #region WriteLine
            Console.WriteLine("|----IMPUT----------------------------------------------------------------------|");
            Console.WriteLine("|Data: {0}.", date);
            Console.WriteLine("|{0} lines with the category of each one of the n trades.", tradeCount);
            Console.WriteLine(" ");
            foreach (var trade in listPortifolio)
            {
                Console.WriteLine("|TRADE - "+ trade.Value +", "+ trade.ClientSector +", " + trade.NextPaymentDate );
            }
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.WriteLine(" ");
            Console.WriteLine("|----OUTPUT--------------------------------------------------------------------|");
            Console.WriteLine("|----CATEGORIES:");
            tradeCategories.ForEach(t => Console.WriteLine(" - " + t));
            Console.ReadKey();
            #endregion
        }
    }
}
