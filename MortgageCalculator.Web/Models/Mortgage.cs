using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Web.Models
{
    [Table("Mortgages")]
    public class Mortgages
    {
        [Key]
        
        public int MortgageId { get; set; }


        //[Required(ErrorMessage = "Please enter name"), MaxLength(50)] \
        
        public string Name { get; set; }
        // [Required(ErrorMessage = "Please Select Effective Start Date")] 
        [DisplayName("Effective Start Date")]
        public Nullable<DateTime> EffectiveStartDate { get; set; }

       // [Required(ErrorMessage = "Please Select Effective End Date")] 
        public Nullable<DateTime>  EffectiveEndDate { get; set; }
        //[Required(ErrorMessage = "Please Enter  Terms In Months")] 
        public int TermsInMonths { get; set; }
        //[Required(ErrorMessage = "Please Enter  CancellationFee ")] 
        public decimal CancellationFee { get; set; }
       //[Required(ErrorMessage = "Please Enter  EstablishmentFee ")] 
        public decimal EstablishmentFee { get; set; }
        public Guid SchemaIdentifier { get; set; }
        public int MortgageType { get; set; }
        public int InterestRepayment { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? LoanAmount { get; set; }
        public int? LoanDuration { get; set; }
        public bool IsActive { get; set; }

    }
}