namespace Empresas.Domain.Models
{
    public class InvestorAutentication
    {
        public InvestorAutentication(string accesToken, string client, string uid)
        {
            AccesToken = accesToken;
            Client = client;
            Uid = uid;
        }

        public string AccesToken { get; private set; }
        public string Client { get; private set; }
        public string Uid { get; private set; }
    }
}