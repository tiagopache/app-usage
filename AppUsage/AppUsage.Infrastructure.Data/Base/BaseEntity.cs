using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects.DataClasses;

namespace AppUsage.Infrastructure.Data.Base
{
    [Serializable]
    public abstract class BaseEntity : IEntityWithKey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public EntityKey EntityKey { get; set; }
    }
}
