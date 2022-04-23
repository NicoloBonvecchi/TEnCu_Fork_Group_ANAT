using System;

namespace Models.ModelConfigurations
{
    [Serializable]
    public class PrefabConfigs
    {
        public Coordinates position;
        public Coordinates eulerRotation;
        public Coordinates scale;
    }
}