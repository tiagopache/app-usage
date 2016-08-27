using AppUsage.Application.Contract.ViewModels.Base;
using AppUsage.Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppUsage.Application.Contract.ViewModels
{
    public class PartnerViewModel : BaseViewModel<PartnerViewModel, Partner>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name"), JsonRequired]
        public string Name { get; set; }

        [JsonProperty("devices")]
        public IList<DeviceViewModel> Devices { get; set; } = new List<DeviceViewModel>();

        [JsonProperty("programs")]
        public IList<ProgramViewModel> Programs { get; set; } = new List<ProgramViewModel>();
    }
}
