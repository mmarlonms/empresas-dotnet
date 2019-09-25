using AutoMapper;
using Empresas.Domain.Models;
using Empresas.IoasysApiAdapter.Clients.Models;

namespace Empresas.IoasysApiAdapter.Mapper
{
    public class IoasysAdapterAutoMapperProfiller : Profile
    {
        public IoasysAdapterAutoMapperProfiller()
        {
            CreateMap<PortfolioResult, Portfolio>();
            CreateMap<EnterpriseTypeResult, EnterpriseType>();
            CreateMap<EnterpriseResult, Enterprise>();
            CreateMap<InvestorResult, Investor>();
        }
    }
}