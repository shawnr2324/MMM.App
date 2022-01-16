using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMM.Models
{
    public  class FinancialEntity_Model
    {
        public int Id { get; set; }
        public int EntityTypeID { get; set; }
        public decimal Balance { get; set; }
        public decimal? InterestRate { get; set; }
        public DateTime? OpenDate { get; set; }
        public decimal? MinimumPayment { get; set; }
        public decimal? APY { get; set; }
        public string EntityName { get; set; }
        public decimal? InitialAmount { get; set; }
        public string EntityType { get; set; }

        public string FormattedBalance => string.Format("{0:C}", Balance);
        public string FormattedInterestRate => InterestRate == null ? null : String.Format("{0:P2}.", InterestRate);
        public string FormattedOpenDate => OpenDate?.ToString("MM/dd/yyyy");
        public string FormattedMinimumPayment => MinimumPayment == null ? null : string.Format("{0:C}", MinimumPayment);
        public string FormattedAPY => APY == null ? null : String.Format("{0:P2}.", APY);
        public string FormattedInitialAmount => InitialAmount == null ? null : string.Format("{0:C}", InitialAmount);
    }
}
