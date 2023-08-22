using UnityEngine;

namespace CodeBase.Infrastructure.ResourceLoad
{
    public interface IResourceLoader
    {
        GameObject Load(string path);
    }
}