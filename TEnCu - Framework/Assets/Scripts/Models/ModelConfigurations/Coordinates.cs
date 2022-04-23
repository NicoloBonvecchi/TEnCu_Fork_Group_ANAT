using UnityEngine;

namespace Models.ModelConfigurations
{
    public class Coordinates
    {
        public float x;
        public float y;
        public float z;
        
        public Vector3 GetVector3()
        {
            return new Vector3(x, y, z);
        }
    }
}