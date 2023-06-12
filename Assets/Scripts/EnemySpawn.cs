using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<WaveConfigSO> WaveConfigs;
    public float timeBetweenWave = 2f;
    public WaveConfigSO currentWave;
    public bool isLooping;
    void Start()
    {
        StartCoroutine(SpawnEnemeWaves());
    } 
    public WaveConfigSO GetCorrentWave()
    {
        return currentWave;
    }
    IEnumerator SpawnEnemeWaves()
    {
        do
        {
            foreach(WaveConfigSO wave in WaveConfigs)
                    {
                    
                        currentWave = wave;
                        for(int i = 0; i < currentWave.GetEnemyCount(); i++){
                        Instantiate(currentWave.GetEnemyPrefab(i), 
                                currentWave.GetStartingWaypoint().position, 
                                Quaternion.identity,
                                transform);
                        yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                    }

                        yield return new WaitForSeconds(timeBetweenWave);

                    }
        }
        
        while(isLooping);

        
    }
 

}
