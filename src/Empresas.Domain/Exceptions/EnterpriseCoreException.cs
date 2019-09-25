using MonteOlimpo.CoreException;

namespace Empresas.Domain.Exceptions
{
    public class EnterpriseCoreException : CoreException<EnterpriseCoreError>
    {
        public EnterpriseCoreException() : base()
        {

        }

        public EnterpriseCoreException(params EnterpriseCoreError[] errors)
        {
            AddError(errors);
        }

        public override string Key => "EnterpriseCoreException";
    }
}