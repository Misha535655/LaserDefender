using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float projectileLifetime = 5f;
    public float baseFiringRate = 0.2f;

    [Header("AI")]
    public bool useAI;
    public float firingRateVariance = 0f;
    public float miniumFiringRate = 0.1f;

    AudioPlayer audioPlayer;

    void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }


    public bool isFiring;

    Coroutine firingCoroutine;

    void Start() {
        
    }

    void Update()
    {
       Fire(); 
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        

    }

    IEnumerator FireContinously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, 
                    transform.position, 
                    Quaternion.identity
                    );
            
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, 
                                        baseFiringRate + firingRateVariance);
        
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, miniumFiringRate, float.MaxValue);

            Destroy(instance, projectileLifetime);

            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(timeToNextProjectile);
        }
        
    } 


        
}
