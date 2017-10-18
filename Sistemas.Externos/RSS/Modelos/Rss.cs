using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sistemas.Externos.RSS.Modelos
{
    [XmlRoot("rss")]
    public class Rss
    {
        [XmlAttribute]
        public string version = "2.0";
        public Channel channel = new Channel();
    }

    [XmlRoot("channel")]
    public class Channel
    {
        public string title;
        public string link;
        public string description;

        [XmlElement]
        public List<object> item = new List<object>();
    }
}
