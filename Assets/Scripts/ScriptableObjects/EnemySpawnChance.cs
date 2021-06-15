using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnChance", menuName = "ScriptableObjects/Spawner/EnemySpawnChance")]
public class EnemySpawnChance : ScriptableObject
{
    public List<EnemyBlank> Enemies;
}

[Serializable]
public class EnemyBlank
{
    public float EnemyPercentageChance;
    public GameObject EnemyPrefab;
}
