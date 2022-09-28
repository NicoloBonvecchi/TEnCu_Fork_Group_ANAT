﻿using System;

namespace Models.ModelConfigurations
{
    [Serializable]
    public class PrefabConfigs
    {
        public Coordinates position;
        public Coordinates eulerRotation;
        public Coordinates scale;
        public MinMax width;
        public MinMax height;
        public MinMax depth;
        public SpeedModifier speedModifier;
    }
}