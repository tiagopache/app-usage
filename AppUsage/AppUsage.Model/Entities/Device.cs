using AppUsage.Infrastructure.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppUsage.Model.Entities
{
    public class Device : BaseIdEntity
    {
        public string Name { get; set; }

        public string MacAddress { get; set; }

        public string IpAddress { get; set; }

        [ForeignKey("Partner")]
        public int PartnerId { get; set; }

        public virtual Partner Partner { get; set; }
    }
}
