using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private const int MAXEnemies = 10;
    [SerializeField] private List<Transform> totems = null;
    [SerializeField] private EnemySpawnChance enemySpawnChance = null;

    private List<HealthSystem> _enemies = new List<HealthSystem>(MAXEnemies);
    private int _zombieKilled;
    private bool _gameOver;

    private void Start()
    {
        for (int i = 0; i < MAXEnemies; i++)
            _enemies.Add(SpawnEnemy());
    }

    private void OnEnable()
    {
        StaticEvent<GameOverArgs>.Subscribe(OnGameOver);
    }

    private void OnDisable()
    {
        StaticEvent<GameOverArgs>.UnSubscribe(OnGameOver);
    }

    private HealthSystem SpawnEnemy()
    {
        var randomPosition = GetNotVisibleTotem().position;
        
        var enemy = ObjectPoolContainer.Instance.GetPooledObject(GetRandomEnemy());
        enemy.transform.position = randomPosition;
        enemy.SetActive(true);

        var enemyHealthSystem = enemy.GetComponent<HealthSystem>();
        enemyHealthSystem.Died += OnEnemyDied;
        
        return enemyHealthSystem;
    }

    private Transform GetNotVisibleTotem()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, totems.Count);
            if (!totems[randomIndex].GetComponentInChildren<Renderer>().isVisible)
                return totems[randomIndex];
        }
    }

    private PoolableObject GetRandomEnemy()
    {
        var enemiesList = enemySpawnChance.Enemies.OrderByDescending(t => t.EnemyPercentageChance).ToList();
        foreach (var enemy in enemiesList)
            if (Random.value <= enemy.EnemyPercentageChance * 0.01f)
                return enemy.EnemyPrefab;

        return enemiesList.Last().EnemyPrefab;
    }

    private void OnEnemyDied(HealthSystem sender)
    {
        sender.Died -= OnEnemyDied;

        _enemies.Remove(sender);
        sender.gameObject.SetActive(false);
        _zombieKilled++;
        StaticEvent<ZombieKilledArgs>.InvokeEvent(sender, new ZombieKilledArgs(_zombieKilled));

        if (!_gameOver)
            SpawnEnemy();
    }

    private void OnGameOver(object sender, GameOverArgs args)
    {
        _gameOver = true;
    }
}
