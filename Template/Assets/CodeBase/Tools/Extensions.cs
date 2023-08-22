using UnityEngine;

namespace CodeBase.Tools
{
    public static class Extensions
    {
        public static bool NotExist(this GameObject gameObject) => 
            gameObject == null || gameObject.Equals(null);
    }
}