using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ICollectabehaviur _collectabeBehaviour;
    private AudioManager _audioManager;
    

    private void Awake()
    {
        _collectabeBehaviour = GetComponent<ICollectabehaviur>();
        _audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();

        if (player != null)
        {
            _collectabeBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
            _audioManager.PlaySfx(_audioManager.healing, _audioManager.healingVolume);
        }
    }
}
