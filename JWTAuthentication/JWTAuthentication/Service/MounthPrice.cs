using JWTAuthentication.Interfaces;
using JWTAuthentication.Models;

namespace JWTAuthentication.Service
{
    public class MounthPrice : IMounthPrice
    {
        public double CalculateData(Credit credit)
        {
           
            double rate = credit.Percent / credit.Money;
            var annuityPayment = (credit.Money * rate) / (1 - 1 / Math.Pow(1 + rate, credit.Mounth));
            var annuityPayment2 = Math.Round(annuityPayment, 2);

            return annuityPayment2;
        }
    }
}
