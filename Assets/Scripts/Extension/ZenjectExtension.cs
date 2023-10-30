using UnityEngine;
using Zenject;

namespace Extension
{
    public static class ZenjectExtension
    {
        public static TObject Instantiate<TObject>(this DiContainer container, TObject prefab, Vector2 position) where TObject: Object
        {
            return container.InstantiatePrefab(prefab, position, Quaternion.identity, null) as TObject;
        }
        
    }
}