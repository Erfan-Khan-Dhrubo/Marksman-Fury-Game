using System;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    private AudioManager _audioManager;
    

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    public void EnemyDestroy(float delay)
    {
        Destroy(gameObject, delay);
    }


    public void PlayEnemyDeathSfx()
    {
        //print("hello");
        _audioManager.PlaySfx(_audioManager.enemyDeath, _audioManager.enemyDeathVolume);
    }
}
