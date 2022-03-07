using MortgageCalculator.Dto;
using MortgageCalculator.Web.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MortgageCalculator.Web.Controllers;

namespace MortgageCalculator.Web.Services
{
    public interface IMortgageService
    {
        List<Mortgage> GetAllMortgages();

        int SaveMortage(Mortgage mortgagedto);
    }

    public class MortgageService : IMortgageService
    {

        IMortgageRepo _mortgageRepo;
        public MortgageService() : this(new MortgageRepo())
        { }

        public MortgageService(IMortgageRepo mortgageRepo)
        {
            this._mortgageRepo = mortgageRepo;
        }

        public List<Mortgage> GetAllMortgages()
        {
            return _mortgageRepo.GetAllMortgages().ToList();
        }

        public int SaveMortage(Mortgage mortgagedto)
        {
            _mortgageRepo = new MortgageRepo();
            return _mortgageRepo.SaveMortgage(mortgagedto);
        }
    }
}