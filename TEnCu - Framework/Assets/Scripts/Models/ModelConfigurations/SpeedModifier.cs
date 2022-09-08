using System;

namespace Models.ModelConfigurations
{
    [Serializable]
    public class SpeedModifier
    {
        public float rotation;
        public float translation;
        //We added zoom
        public float zoom;
    }
}