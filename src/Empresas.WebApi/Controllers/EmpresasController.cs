using Empresas.Domain.Adapters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Empresas.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly ILogger<EmpresasController> logger;

        public EmpresasController(ILogger<EmpresasController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("ShowAllEnterprises")]
        public IActionResult ShowAllEnterprises([FromServices] IIoasysApiAdapter ioasysApiAdapter)
        {
            logger.LogInformation("Obtendo todos ps Empreedimentos");
            return Ok(ioasysApiAdapter.ShowAllEnterprises());
        }

        [HttpGet("ShowEnterpriseByID")]
        public IActionResult ShowEnterpriseByID([FromServices] IIoasysApiAdapter ioasysApiAdapter, int entrepriseId)
        {
            logger.LogInformation("Obtendo Empreedimentos para o id {entrepriseId}", entrepriseId);
            return Ok(ioasysApiAdapter.ShowEnterpriseByID(entrepriseId));
        }

        [HttpGet("ShowEnterpriseByNameAndType")]
        public IActionResult ShowEnterpriseByNameAndType([FromServices] IIoasysApiAdapter ioasysApiAdapter, string name, int type )
        {
            logger.LogInformation("Obtendo Empreedimentos por filtros");

            var filters = new Dictionary<string, object>();
            filters.Add("name", name);
            filters.Add("enterprise_types", type);

            return Ok(ioasysApiAdapter.ShowEnterpriseByFilter(filters));
        }
    }
}
