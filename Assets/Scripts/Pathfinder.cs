using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{   
    EnemySpawn enemySpawn;
    public WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex;

    void Awake()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    void Start()
    {
        waveConfig = enemySpawn.GetCorrentWave();
        waypoints = waveConfig.GetWaypoint();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FolowPath();
    }

    void FolowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMovieSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if(transform.position == targetPosition){
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
