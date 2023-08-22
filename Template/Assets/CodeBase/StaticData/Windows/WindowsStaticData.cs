using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Windows
{
    [CreateAssetMenu(menuName = "StaticData/Window static data", fileName = "WindowStaticData", order = 0)]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}