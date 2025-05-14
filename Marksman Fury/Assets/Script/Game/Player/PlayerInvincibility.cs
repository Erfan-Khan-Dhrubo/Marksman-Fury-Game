using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration;
    
    private InvisibilityController _invisibilityController;
    
    [SerializeField] private Color flashColor;
    [SerializeField] private int numOfFlashes;

    private void Awake()
    {
        _invisibilityController = GetComponent<InvisibilityController>();
    }

    public void StartInvincibility()
    {
        _invisibilityController.StartInvincibility(invincibilityDuration, flashColor, numOfFlashes);
    }
}
