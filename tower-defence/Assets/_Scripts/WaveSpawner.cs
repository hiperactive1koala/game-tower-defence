using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    #region Events
    public event EventHandler<OnProgressChangedEventsArgs> OnCountdownChanged;
    public class OnProgressChangedEventsArgs : EventArgs { public float Countdown; }
    #endregion

    #region SerializeFields
    
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _waveInterval = 5f;
    
    #endregion

    private List<GameObject> _enemies;
    private float _countdown = 2f;
    private int _waveIndex;


    #region Unity
    private void Start() => _enemies = new List<GameObject>();

    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = _waveInterval;
        }

        _countdown -= Time.deltaTime;
        OnCountdownChanged?.Invoke(this, new OnProgressChangedEventsArgs()
        {
            Countdown = _countdown
        });
    }
    #endregion

    private IEnumerator SpawnWave()
    {
        _waveIndex++;
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, _spawnPoint.position,_spawnPoint.rotation);
        _enemies.Add(enemy.gameObject);
    }

    public List<GameObject> GetEnemyList() => _enemies;
    public void RemoveEnemy(GameObject destroyedEnemy) => _enemies.Remove(destroyedEnemy);
}
