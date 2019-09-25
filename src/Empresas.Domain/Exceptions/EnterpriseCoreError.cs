using MonteOlimpo.CoreException;

namespace Empresas.Domain.Exceptions
{
    public class EnterpriseCoreError : CoreError
    {
        protected EnterpriseCoreError(string key, string message) : base(key, message)
        {
        }

        public static readonly EnterpriseCoreError EnterpriseNotFound = new EnterpriseCoreError("EnterpriseNotFound", "No Enterprise found for informed id ");
        public static readonly EnterpriseCoreError EnterpriseFailed = new EnterpriseCoreError("EnterpriseFailed", "Failed to get Enterprise, please contact admin.");
    }
}