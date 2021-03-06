using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DsGraphListDto : DsGraphDto
{
    [JsonProperty("verbindingslijst")] public object[][][]? AdjacencyList { get; set; }
    [JsonProperty("verbindingslijst_gewogen")] public object[][][]? WeightAdjacencyList { get; set; }
}