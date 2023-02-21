using ProtoBuf;

namespace KafkaExample.Models
{
    [ProtoContract]
    public class Package
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string? Name { get; set; }
        [ProtoMember(3)]
        private IList<Content>? contents;
        public IList<Content> Contents
        {
            get { return contents ?? new List<Content>(); }
            set { contents = value; }
        }
    }
}