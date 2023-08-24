using System;
using CodeBase.Tools;
using UnityEngine;

namespace CodeBase.Infrastructure.ResourceLoad
{
    public class ResourceLoader : IResourceLoader
    {
        public GameObject Load(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab.NotExist())
            {
                throw new NullReferenceException(
                    $"<b>ResourceLoader</b>: Object at path '{path}' doesn't exist");
            }

            return prefab;
        }
    }
}