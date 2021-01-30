using UnityEngine;

namespace CatFinder
{
    public static class VectorExt
    {
        public static Vector3 ToXZVector3(this Vector2 vector)
        {
            return new Vector3(vector.x, 0f, vector.y);
        }
    }
}