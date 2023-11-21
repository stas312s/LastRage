using System;
using UnityEngine;
using Zenject;
using Extension;
using Player.Interfaces;
using Random = UnityEngine.Random;


namespace Weapon.Lootbox
{
    public class LootboxTriggerZone: MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private IPlayerPosition _playerPosition;
        
        [SerializeField] private Lootbox _lootbox;

        private float _distanceX = 13f;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerMove>(out var playerMove))
            {
                SpawnLootbox();
                Destroy(gameObject);
            }
        }

        private void SpawnLootbox()
        {
            int randomIndex = Random.Range(-1, 1);
            float randomDistanceX = _distanceX;
            if (randomIndex == -1)
            {
                randomDistanceX = _distanceX * randomIndex;
            }
            
            Vector2 spawnPosition = _playerPosition.Position + new Vector2(randomDistanceX, 5);
            
            _diContainer.Instantiate(_lootbox, spawnPosition);
        }
    }
}