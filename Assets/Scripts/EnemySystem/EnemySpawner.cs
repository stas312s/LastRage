using Player.Interfaces;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
using Extension;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    
    [Inject] private IPlayerPosition _playerTransform;
    [Inject] private DiContainer _container;
    
    private float _spawnDistance = 20f;
    private float _spawnInterval = 3f;
    private float _lastSpawnTime;

    private void Start()
    {
        _lastSpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _lastSpawnTime >= _spawnInterval)
        {
            EnemySpawn();
            _lastSpawnTime = Time.time;
        }
    }


    private void EnemySpawn()
    {
        float direction = Random.Range(0, 2) == 0 ? -1 : 1;
        
        Vector2 playerPosition =  new Vector2(_playerTransform.Position.x, -3); 
        Vector2 spawnPosition = playerPosition + new Vector2(_spawnDistance * direction, 0);

        _container.Instantiate(_enemyPrefab, spawnPosition);
    }

}
