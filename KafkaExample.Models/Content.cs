using ProtoBuf;

namespace KafkaExample.Models
{
    [ProtoContract]
    public class Content
    {
        [ProtoMember(1)]
        public string? Name { get; set; }
        [ProtoMember(2)]
        public int WeightInPounds { get; set; }
    }
}
