using AppUsage.Infrastructure.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppUsage.Model.Entities
{
    public class Partner : BaseIdEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual IList<Device> Devices { get; set; } = new List<Device>();

        public virtual IList<Program> Programs { get; set; } = new List<Program>();
    }

}
