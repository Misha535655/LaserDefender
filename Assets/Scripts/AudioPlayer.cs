using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    public AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    public AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;


    public void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,
                                        Camera.main.transform.position,
                                        volume);
        }
    }
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }
}
