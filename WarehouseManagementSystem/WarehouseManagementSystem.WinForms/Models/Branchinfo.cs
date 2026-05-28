using System.Text.Json.Serialization;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class BranchInfo
    {
        [JsonPropertyName("BranchId")]
        public string BranchId { get; set; } = string.Empty;

        [JsonPropertyName("BranchName")]
        public string BranchName { get; set; } = string.Empty;

        [JsonPropertyName("BranchType")]
        public string BranchType { get; set; } = string.Empty;

        [JsonPropertyName("City")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("Address")]
        public string Address { get; set; } = string.Empty;

        public override string ToString() => BranchName;
    }
}