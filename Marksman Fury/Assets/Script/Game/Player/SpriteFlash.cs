using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteFlash : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void StartFlash(float flashDuration, Color flashColor, int numberOfFlashes)
    {
        StartCoroutine(FlashCoroutine(flashDuration, flashColor, numberOfFlashes));
        
    }

    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOfFlashes)
    {
        Color startColor = _spriteRenderer.color;
        float elapsedTime = 0;
        float elapsedFlashPercentage = 0;

        while (elapsedTime < flashDuration)
        {
            elapsedTime += Time.deltaTime;
            elapsedFlashPercentage = elapsedTime / flashDuration;

            if (elapsedFlashPercentage >= 1f)
            {
                elapsedFlashPercentage = 1f;
            }
            
            
            float pingpongPercentage = Mathf.PingPong(elapsedFlashPercentage * 2  * numberOfFlashes,1); // !
            _spriteRenderer.color = Color.Lerp(startColor, flashColor, pingpongPercentage);
            
            yield return null;

        }

    }
}
