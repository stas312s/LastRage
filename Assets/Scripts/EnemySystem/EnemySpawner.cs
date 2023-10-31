using Player.Interfaces;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
using Extension;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    
    [Inject] private IPlayerPosition _playerTransform;
    [Inject] private DiContainer _container;
    
    private float _spawnMinDistance = 20f;
    private float _spawnMaxDistance = 30f;
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
            SpawnEnemy(Direction.Right);
            SpawnEnemy(Direction.Left);
            _lastSpawnTime = Time.time;
        }
    }

    private void SpawnEnemy(Direction direction)
    {
        float spawnDistance = Random.Range(_spawnMinDistance, _spawnMaxDistance);
        Vector2 playerPosition =  new Vector2(_playerTransform.Position.x, 5); 
        
        Vector2 spawnPosition = playerPosition + new Vector2(spawnDistance * (direction == Direction.Right? 1:-1), 0);
        
        _container.Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], spawnPosition);
    }

   

    public enum Direction
    {
        Right,
        Left
    }

}
