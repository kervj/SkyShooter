using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Config", menuName = "Wave Configuration")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private WaypointsContainer pathPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float intervalBetweenEnemySpawns = 1f;
    [SerializeField] private float spawnTimeVariance = 0f;
    [SerializeField] private float minimumSpawnTime = 0.2f;

    public Transform GetFirstWaypoint()
    {
        return pathPrefab.waypoints[0];
    }

    public List<Transform> GetWaypoints()
    {
        return pathPrefab.waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        if (index >= 0 && index < enemyPrefabs.Count)
        {
            return enemyPrefabs[index];
        }
        else
        {
            Debug.LogError("Invalid enemy prefab index!");
            return null;
        }
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(intervalBetweenEnemySpawns - spawnTimeVariance,
            intervalBetweenEnemySpawns + spawnTimeVariance);

        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}