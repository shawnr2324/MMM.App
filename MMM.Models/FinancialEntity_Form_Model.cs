using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MMM.Models
{
    public class FinancialEntity_Form_Model 
    {
        public int Id { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please select a valid entity type.")]
        public int EntityTypeID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [RequiredIf("EntityTypeID", 3), DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal? InterestRate { get; set; }

        //Custom to check if entity type ID is Savings or Debt
        [NotMapped]
        public bool SavingsAndDebt
        {
            get { return this.EntityTypeID == 2 || this.EntityTypeID == 3;}
        }

        [RequiredIf("SavingsAndDebt", true)]
        public DateTime? OpenDate { get; set; }

        [RequiredIf("EntityTypeID", 3), DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal? MinimumPayment { get; set; }

        [RequiredIf("EntityTypeID", 2), DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal? APY { get; set; }

        [Required]
        public string EntityName { get; set; }

        [RequiredIf("SavingsAndDebt", true), DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal? InitialAmount { get; set; }

    }
}
