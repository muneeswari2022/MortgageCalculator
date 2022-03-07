using MortgageCalculator.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MortgageCalculator.Web.Models;
using MortgageDTO = MortgageCalculator.Dto.Mortgage;
using ModelMortgage = MortgageCalculator.Web.Models.Mortgages;
using MortgageCalculator.Dto;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace MortgageCalculator.Web.Repos
{
    public interface IMortgageRepo
    {
        List<MortgageDTO> GetAllMortgages();
        int SaveMortgage(MortgageDTO mortgage);
    }

    public class MortgageRepo : IMortgageRepo
    {
        public List<MortgageDTO> GetAllMortgages()
        {
            using (var context = new MortgageContext())
            {
                var mortgages = context.TblMortgage.Where(x=>x.IsActive == true).ToList().OrderBy(x=>x.MortgageType).ThenBy(x => x.InterestRate);
                List<MortgageDTO> result = new List<MortgageDTO>();
                foreach (var mortgage in mortgages)
                {
                    result.Add(new MortgageDTO()
                    {
                        Name = mortgage.Name,
                        EffectiveStartDate = (DateTime)mortgage.EffectiveStartDate,
                        EffectiveEndDate = (DateTime)mortgage.EffectiveEndDate,
                        CancellationFee = (Decimal)mortgage.CancellationFee,
                        EstablishmentFee = (Decimal)mortgage.CancellationFee,
                        InterestRepayment = (InterestRepayment)Enum.Parse(typeof(InterestRepayment), mortgage.InterestRepayment.ToString()),
                        MortgageId = mortgage.MortgageId,
                        MortgageType = (MortgageType)Enum.Parse(typeof(MortgageType), mortgage.MortgageType.ToString()),
                        TermsInMonths = (int)mortgage.TermsInMonths,
                        IsActive = (bool)mortgage.IsActive,
                        LoanAmount = mortgage.LoanAmount,
                        LoanDuration = mortgage.LoanDuration,
                        InterestRate = mortgage.InterestRate,
                       // SchemaIdentifier = (Guid)mortgage.SchemaIdentifier
                    }
                    );
            }
            return result;
        }
    }
    
    public int SaveMortgage(MortgageDTO MortgageDTO)
    {
        try
        {
            int result = 0;
            using (var objDC = new MortgageContext())
            {
                ModelMortgage MdlMortgage = new ModelMortgage();
                MdlMortgage.MortgageId = MortgageDTO.MortgageId;
                MdlMortgage.MortgageType = (int)MortgageDTO.MortgageType;
                MdlMortgage.Name = MortgageDTO.Name;
                MdlMortgage.EffectiveStartDate = Convert.ToDateTime(MortgageDTO.EffectiveStartDate.ToString("dd/MM/yyyy"));
                MdlMortgage.EffectiveEndDate = Convert.ToDateTime(MortgageDTO.EffectiveEndDate.ToShortDateString());
                MdlMortgage.TermsInMonths = MortgageDTO.TermsInMonths;
                MdlMortgage.CancellationFee = MortgageDTO.CancellationFee;
                MdlMortgage.EstablishmentFee = MortgageDTO.EstablishmentFee;
                MdlMortgage.SchemaIdentifier = MortgageDTO.SchemaIdentifier;
                MdlMortgage.InterestRepayment = (int)MortgageDTO.InterestRepayment;
                MdlMortgage.IsActive = MortgageDTO.IsActive;
                MdlMortgage.InterestRate = MortgageDTO.InterestRate;
                MdlMortgage.LoanDuration = MortgageDTO.LoanDuration;
                MdlMortgage.LoanAmount = MortgageDTO.LoanAmount;

                objDC.TblMortgage.Add(MdlMortgage);
                result = objDC.SaveChanges();


                return result;
            }
        }
        catch (DbEntityValidationException dbEx)
        {
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                        validationErrors.Entry.Entity.GetType().FullName,
                        validationError.PropertyName,
                        validationError.ErrorMessage);
                }
            }

            throw;  // You can also choose to handle the exception here...
        }
    }



}
}
