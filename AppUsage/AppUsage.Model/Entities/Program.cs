using AppUsage.Infrastructure.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppUsage.Model.Entities
{
    public class Program : BaseIdEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string AssemblyName { get; set; }

        public virtual IList<Partner> Partners { get; set; } = new List<Partner>();
    }
}
