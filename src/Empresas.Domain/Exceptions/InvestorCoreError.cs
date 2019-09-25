using MonteOlimpo.CoreException;

namespace Empresas.Domain.Exceptions
{
    public class InvestorCoreError : CoreError
    {
        protected InvestorCoreError(string key, string message) : base(key, message)
        {
        }

        public static readonly InvestorCoreError InvestorFailed = new InvestorCoreError("InvestorFailed", "Failed to get Investor, please contact admin.");
    }
}