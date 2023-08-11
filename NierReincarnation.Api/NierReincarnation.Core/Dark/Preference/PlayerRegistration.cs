using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NierReincarnation.Core.Dark.Preference
{
    // Dark.Preference.PlayerRegistration
    class PlayerRegistration
    {
        private static readonly string kBlockAdId = Guid.Empty.ToString("D");

       
        public bool IsTransfer { get; set; }
       
        public bool IsTransferApple { get; set; }
       
        public bool IsTransferFacebook { get; set; }
       
        [JsonProperty("_uuid")]
        public string Uuid { get; set; } = Guid.NewGuid().ToString("D");
       
        [JsonProperty("_signature")]
        public string Signature { get; set; } = string.Empty;
       
        [JsonProperty("_userId")]
        public long UserId { get; set; }
       
        [JsonProperty("_playerId")]
        public long PlayerId { get; set; }
       
        [JsonProperty("_terminalId")]
        public string TerminalId { get; set; }
       
        [JsonProperty("_advertisingId")]
        public string AdvertisingId { get; set; }
       
        [JsonProperty("_isTrackingEnabled")]
        public bool IsTrackingEnabled { get; set; }
       
        [JsonProperty("_id")]
        private string _id;
       
        [JsonProperty("_serverAddressAndPort")]
        public string ServerAddressAndPort { get; set; }
       
        private Guid _guid;
       
        [JsonProperty("_momTappedCount")]
        public int MomTappedCount { get; set; }

        public PlayerRegistration(string uuid)
        {
            _guid = Guid.NewGuid();
            if (string.IsNullOrEmpty(uuid))
                uuid = _guid.ToString();

            Uuid = uuid;
        }

        public Task UpdateAdvertisingIdAsync()
        {
            // Needs access to unity classes to attain advertising information

            AdvertisingId = Guid.NewGuid().ToString("N");
            IsTrackingEnabled = false;

            return Task.CompletedTask;
        }
    }
}
