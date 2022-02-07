using UnityEngine;

namespace ObjectPool
{
    [CreateAssetMenu(fileName = "NewPool", menuName = "Object Pool", order = 1)]
    public class Pool_SO : ScriptableObject
    {
        public string tag;
        public int size;
        public bool isAutoExpand;
        public PoolElement prefab;
    }
}