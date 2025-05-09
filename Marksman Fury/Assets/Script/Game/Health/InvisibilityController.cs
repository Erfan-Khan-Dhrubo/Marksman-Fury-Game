using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityController : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }

    public void StartInvincibility(float invincibilityDuration)  
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)   // Coroutine ?
    {
        _healthController.isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        _healthController.isInvincible = false;
    }
}
