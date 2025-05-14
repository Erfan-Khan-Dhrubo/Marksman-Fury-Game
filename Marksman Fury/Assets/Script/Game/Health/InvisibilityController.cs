using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityController : MonoBehaviour
{
    private HealthController _healthController;
    private SpriteFlash _spriteFlash;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _spriteFlash = GetComponent<SpriteFlash>();
    }

    public void StartInvincibility(float invincibilityDuration, Color flashColor, int numOfFlashes)  
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration, flashColor, numOfFlashes));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration, Color flashColor, int numOfFlashes)   // Coroutine ?
    {
        _healthController.isInvincible = true;
        yield return _spriteFlash.FlashCoroutine(invincibilityDuration, flashColor, numOfFlashes);
        _healthController.isInvincible = false;
    }
}
