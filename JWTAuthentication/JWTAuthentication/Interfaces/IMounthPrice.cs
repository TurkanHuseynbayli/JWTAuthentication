using JWTAuthentication.Models;

namespace JWTAuthentication.Interfaces
{
    public interface IMounthPrice
    {
        public double CalculateData(Credit credit);
    }
}
