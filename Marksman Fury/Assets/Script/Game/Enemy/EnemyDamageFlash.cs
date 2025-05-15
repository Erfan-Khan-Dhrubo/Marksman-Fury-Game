using UnityEngine;

public class EnemyDamageFlash : MonoBehaviour
{
    [SerializeField] private float flashDuration;
    
    [SerializeField] private Color flashColor;
    
    [SerializeField] private int numberOfFlashes;
    
    private SpriteFlash _spriteFlash;
    
    private void Awake()
    {
        _spriteFlash = GetComponent<SpriteFlash>();
    }
    
    public void StartFlash()
    {
        _spriteFlash.StartFlash(flashDuration, flashColor, numberOfFlashes);
    }
}
