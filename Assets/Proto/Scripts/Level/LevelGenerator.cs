using System.Collections.Generic;
using System.Linq;
using Proto.Scripts.Item;
using UnityEngine;

namespace Proto.Scripts.Level
{
    public interface ILevelGenerator
    {
        void Generate();
    }
    
    public class LevelGenerator : MonoBehaviour, ILevelGenerator
    {
        [SerializeField] private List<GameObject> itemPrefabs;
        
        public void Generate()
        {
            var points = FindObjectsByType<ItemSpawnPoint>(FindObjectsSortMode.None);
            _itemSpawns = points.Select(p => p.GetSpawnData()).ToList();
            
            foreach (var spawn in _itemSpawns)
            {
                var validPrefabs = GetValidItemPrefabs(spawn);

                if (validPrefabs.Any())
                {
                    InstantiatePrefabs(spawn, validPrefabs);
                }
            }
        }

        private List<GameObject> GetValidItemPrefabs(ItemSpawn spawn)
        {
            return itemPrefabs.Where(p =>
                {
                    var item = p.GetComponent<IItem>();
                    return item != null && item.Size() <= spawn.Size();
                }
            ).ToList();
        }

        private static void InstantiatePrefabs(ItemSpawn spawn, List<GameObject> prefabs)
        {
            Object.Instantiate(
                prefabs[Random.Range(0, prefabs.Count)], 
                spawn.Transform().position, 
                spawn.Transform().rotation);
        }

        private  List<ItemSpawn> _itemSpawns;
    }
}

