using AppUsage.Application.Contract.ViewModels.Base;
using AppUsage.Model.Entities;
using Newtonsoft.Json;

namespace AppUsage.Application.Contract.ViewModels
{
    public class ProgramViewModel : BaseViewModel<ProgramViewModel, Program>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("assembly-name")]
        public string AssemblyName { get; set; }
    }
}
