using System.ComponentModel.DataAnnotations;

namespace AppUsage.Infrastructure.Data.Base
{
    public abstract class BaseConcurrencyGuidEntity : BaseGuidEntity
    {
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
