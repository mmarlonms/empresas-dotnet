using System.ComponentModel.DataAnnotations;

namespace Empresas.IoasysApiAdapter
{
    public class IoasysApiAdapterConfiguration
    {
        [Required]
        public string UrlBase { get; set; }
    }
}