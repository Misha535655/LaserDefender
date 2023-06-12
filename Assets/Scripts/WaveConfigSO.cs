using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject 
{
    public Transform pathPrefab; 
    public List<GameObject> enemies;
    public float movieSpeedEnemy = 10;
    public float timeBetweenEnemySpawns = 1f;
    public float spawnTimeVariants = 0f;
    public float minimumSpawnTime = 0.2f;



    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoint()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMovieSpeed()
    {
        return movieSpeedEnemy;
    }

    public int GetEnemyCount()
    {
       return enemies.Count; 
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemies[index];
    }

    public float GetRandomSpawnTime()
    {
         float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariants, 
                                        timeBetweenEnemySpawns + spawnTimeVariants);
        
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
