using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool isPlayer;
    public int health = 50;
    public ParticleSystem hitEffect;
    
    public bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();  
        scoreKeeper = FindObjectOfType<ScoreKeeper>();  
        levelManager = FindObjectOfType<LevelManager>();  
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.PlayDamageClip();
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0 )
        { 
            Die();
        }
    }

    void Die()
    {
        if(!isPlayer){
            scoreKeeper.ModifyScore(10);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
        
    }
    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake){
            cameraShake.Play();
        }
    }

    public int GetHelth()
    {
        return health;
    }
}
