using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace MMM.Models
{
    public class FinancialEntity_Form_Model 
    {
        public int Id { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please select a valid entity type.")]
        public int EntityTypeID { get; set; }

        //Custom to check if entity type ID is Savings or Debt
        [NotMapped]
        public bool SavingsAndDebt
        {
            get { return this.EntityTypeID == 2 || this.EntityTypeID == 3; }
        }

        [NotMapped]
        public bool Savings
        {
            get { return this.EntityTypeID == 2; }
        }

        [NotMapped]
        public bool Debt
        {
            get { return this.EntityTypeID == 3; }
        }

        [Required]
        public string UserID { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required_EntityTypeConditional("Debt", "InterestRate"), DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal? InterestRate { get; set; }

        [Required_EntityTypeConditional("SavingsAndDebt", "OpenDate"), DataType(DataType.Date)]
        public DateTime? OpenDate { get; set; }

        [Required_EntityTypeConditional("Debt", "MinimumPayment"), DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal? MinimumPayment { get; set; }

        [Required_EntityTypeConditional("Savings", "APY"), DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal? APY { get; set; }

        [Required]
        public string EntityName { get; set; }

        [Required_EntityTypeConditional("SavingsAndDebt", "InitialAmount"), DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal? InitialAmount { get; set; }

    }

    //Custom Validation
    public class Required_EntityTypeConditional : ValidationAttribute
    {
        private string _entityTypeName { get; set; }
        private bool _valid { get; set; }
        private string _fieldName { get; set; }

        public Required_EntityTypeConditional(string entityTypeName, string fieldName)
        {
            _entityTypeName = entityTypeName;
            _fieldName = fieldName;
        }

        public string GetErrorMessage() => $"{_fieldName} is required.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = (FinancialEntity_Form_Model)validationContext.ObjectInstance;
            if (GetPropValue(obj, _fieldName) == null)
            {
                switch (_entityTypeName)
                {
                    case "Debt":
                        if (obj.Debt)
                        {
                            _valid = false;
                        }
                        else
                        {
                            _valid = true;
                        }
                        break;

                    case "Savings":
                        if (obj.Savings)
                        {
                            _valid = false;
                        }
                        else
                        {
                            _valid = true;
                        }
                        break;
                    case "SavingsAndDebt":
                        if (obj.SavingsAndDebt)
                        {
                            _valid = false;
                        }
                        else
                        {
                            _valid = true;
                        }
                        break;

                    default:
                        _valid = true;
                        break;
                }

                if (!_valid)
                {
                    return new ValidationResult(GetErrorMessage(), new[] { validationContext.MemberName });
                }
            }

            return ValidationResult.Success;

        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

    }
}
