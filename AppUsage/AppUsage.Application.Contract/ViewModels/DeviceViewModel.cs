﻿using AppUsage.Application.Contract.ViewModels.Base;
using AppUsage.Model.Entities;
using Newtonsoft.Json;

namespace AppUsage.Application.Contract.ViewModels
{
    public class DeviceViewModel : BaseViewModel<DeviceViewModel, Device>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name"), JsonRequired]
        public string Name { get; set; }

        [JsonProperty("mac-address"), JsonRequired]
        public string MacAddress { get; set; }

        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }
    }
}
