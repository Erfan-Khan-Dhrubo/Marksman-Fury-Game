using System;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    [Header("---- Audio Source ----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource effectsSource;
    
    [Header("---- Audio Clips ----")]
    public AudioClip backgroundMusic;
    public AudioClip gameOverMusic;
    public AudioClip enemyDeath;
    public AudioClip gunshot;
    public AudioClip playerDamage;
    public AudioClip healing;
    
    [Header("---- Audio Volume ----")]
    [Range(0f, 1f)] public float backgroundMusicVolume;
    [Range(0f, 1f)] public float healingVolume;
    [Range(0f, 1f)] public float gameOverMusicVolume;
    [Range(0f, 1f)] public float enemyDeathVolume;
    [Range(0f, 1f)] public float gunshotVolume;
    [Range(0f, 1f)] public float playerDamageVolume;
    
    
    
    public void Start()
    {
        musicSource.volume = backgroundMusicVolume;
        musicSource.PlayOneShot(backgroundMusic);
    }

    public void PlaySfx(AudioClip clip, float volume)
    {
        
        effectsSource.volume =  volume;
        effectsSource.PlayOneShot(clip);
        //print(clip.name);
        
    }

   
}
