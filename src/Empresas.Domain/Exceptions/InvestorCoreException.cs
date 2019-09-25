using MonteOlimpo.CoreException;

namespace Empresas.Domain.Exceptions
{
    public class InvestorCoreException : CoreException<InvestorCoreError>
    {
        public InvestorCoreException() : base()
        {

        }

        public InvestorCoreException(params InvestorCoreError[] errors)
        {
            AddError(errors);
        }

        public override string Key => "InvestorCoreException";
    }
}