using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DeathEffects
{
    public class Config : IRocketPluginConfiguration
    {

        public bool Enabled;
        
        [XmlArrayItem(ElementName = "Effect")]
        public List<ushort> Effects;

        public void LoadDefaults()
        {
            Enabled = true;
            Effects = new List<ushort>()
            {
                120
            };
        }
    }
}