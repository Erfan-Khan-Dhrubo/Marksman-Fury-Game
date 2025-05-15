using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityController : MonoBehaviour
{
    private HealthController _healthController;
    private SpriteFlash _spriteFlash;
    private AudioManager _audioManager;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _spriteFlash = GetComponent<SpriteFlash>();
        _audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    public void StartInvincibility(float invincibilityDuration, Color flashColor, int numOfFlashes)  
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration, flashColor, numOfFlashes));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration, Color flashColor, int numOfFlashes)   // Coroutine ?
    {
        
        _healthController.isInvincible = true;
        _audioManager.PlaySfx(_audioManager.playerDamage);
        yield return _spriteFlash.FlashCoroutine(invincibilityDuration, flashColor, numOfFlashes);
        _healthController.isInvincible = false;
    }
}
