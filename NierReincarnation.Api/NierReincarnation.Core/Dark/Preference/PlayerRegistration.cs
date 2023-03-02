using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NierReincarnation.Core.Dark.Preference
{
    // Dark.Preference.PlayerRegistration
    class PlayerRegistration
    {
        private static readonly string kBlockAdId = Guid.Empty.ToString("D");

        // 0x10
        public bool IsTransfer { get; set; }
        // 0x11
        public bool IsTransferApple { get; set; }
        // 0x12
        public bool IsTransferFacebook { get; set; }
        // 0x18
        [JsonProperty("_uuid")]
        public string Uuid { get; set; } = Guid.NewGuid().ToString("D");
        // 0x20
        [JsonProperty("_signature")]
        public string Signature { get; set; } = string.Empty;
        // 0x28
        [JsonProperty("_userId")]
        public long UserId { get; set; }
        // 0x30
        [JsonProperty("_playerId")]
        public long PlayerId { get; set; }
        // 0x38
        [JsonProperty("_terminalId")]
        public string TerminalId { get; set; }
        // 0x40
        [JsonProperty("_advertisingId")]
        public string AdvertisingId { get; set; }
        // 0x48
        [JsonProperty("_isTrackingEnabled")]
        public bool IsTrackingEnabled { get; set; }
        // 0x50
        [JsonProperty("_id")]
        private string _id;
        // 0x58
        [JsonProperty("_serverAddressAndPort")]
        public string ServerAddressAndPort { get; set; }
        // 0x60
        private Guid _guid;
        // 0x70
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
