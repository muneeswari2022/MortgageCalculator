using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MortgageCalculator.Dto
{
    public class Mortgage
    {
        public int MortgageId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Mortgage Type")]
        public MortgageType MortgageType { get; set; }
        [Display(Name = "Interest Repayment")]
        public InterestRepayment InterestRepayment { get; set; }
        [Display(Name = "Effective Start Date")]        
        public DateTime EffectiveStartDate { get; set; }
        [Display(Name = "Effective End Date")]
        public DateTime EffectiveEndDate { get; set; }
        [Display(Name = "Terms (In Months)")]
        public int TermsInMonths { get; set; }
        [Display(Name = "Cancellation Fee")]
        public decimal CancellationFee { get; set; }
        [Display(Name = "Establishment Fee")]
        public decimal EstablishmentFee { get; set; }
        public Guid SchemaIdentifier { get; internal set; } = Guid.NewGuid();
        public bool IsActive { get; set; }

        [Display(Name = "Interest Rate")]
        public decimal? InterestRate { get; set; }
        [Display(Name = "Loan Amount")]
        public decimal? LoanAmount { get; set; }
        [Display(Name = "Loan Duration")]
        public int? LoanDuration { get; set; }
    }

    public enum MortgageType
    {
        Variable,
        Fixed
    }

    public enum InterestRepayment
    {
        InterestOnly,
        PrincipalAndInterest
    }

    
}
