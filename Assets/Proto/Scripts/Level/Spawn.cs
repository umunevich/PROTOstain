using System.Collections.Generic;
using UnityEngine;

namespace Proto.Scripts.Level
{
    public class ItemSpawnPoint : MonoBehaviour
    {
        [SerializeField] private ItemSpawn.SizeType size;
        
        public ItemSpawn GetSpawnData() => new ItemSpawn(transform, size);
    }

    public class ItemSpawn
    {
        public enum SizeType { Small, Medium, Large }

        public ItemSpawn(Transform transform, SizeType size)
        {
            _transform = transform;
            _size = size;
        }

        public Transform Transform() => _transform;
        public float Size() => Sizes[_size];
        
        private void OnDrawGizmos()
        {
            Gizmos.color = _size switch
            {
                ItemSpawn.SizeType.Small => Color.green,
                ItemSpawn.SizeType.Medium => Color.yellow,
                ItemSpawn.SizeType.Large => Color.red,
                _ => Color.white
            };
            
            Gizmos.DrawWireSphere(_transform.position, 0.2f);

            Gizmos.DrawRay(_transform.position, _transform.forward * 0.5f);
        }
        
        private readonly Transform _transform;
        private readonly SizeType _size;
        
        public static readonly Dictionary<SizeType, float> Sizes = new()
        {
            { SizeType.Small, 4f },
            { SizeType.Medium, 6f },
            { SizeType.Large, 8f },
        };
    }
}

