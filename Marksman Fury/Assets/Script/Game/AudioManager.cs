using System;
using UnityEngine;

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
    
    
    public void Start()
    {
        musicSource.PlayOneShot(backgroundMusic);
    }

    public void PlaySfx(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

   
}
