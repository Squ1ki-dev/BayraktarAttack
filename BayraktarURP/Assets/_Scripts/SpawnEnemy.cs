using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy Instance;

    private int _waveNumber = 0;
    public int _spawnEnemyAmount = 0,
               _maxEnemyAmount,
               EnemyKilled = 0;

    [SerializeField] private GameObject _tankPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private void Awake() 
    {
        Instance = this;
        StartWave();
    }

    private void Update() 
    {
        if(EnemyKilled >= _spawnEnemyAmount)
            NextWave();
        if(_spawnEnemyAmount == _maxEnemyAmount)
            LastWave();
    }

    private void Spawn()
    {
        int _spawnPos = Random.Range(0, _spawnPoints.Count);
        Instantiate(_tankPrefab, _spawnPoints[_spawnPos].transform.position, Quaternion.identity);
    }

    private void StartWave()
    {
        _waveNumber = 1;
        _spawnEnemyAmount = 2;
        LoopSpawn();
    }

    private void NextWave()
    {
        _waveNumber++;
        _spawnEnemyAmount += 2;
        LoopSpawn();
    }

    private void LastWave()
    {
        _spawnEnemyAmount = 10;
        LoopSpawn();
    }

    private void LoopSpawn()
    {
        EnemyKilled = 0;
        
        for (int i = 0; i < _spawnEnemyAmount; i++)
        {
            Spawn();
        }
    }
}
