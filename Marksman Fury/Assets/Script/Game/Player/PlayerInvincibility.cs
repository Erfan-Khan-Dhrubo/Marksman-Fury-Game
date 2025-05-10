using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration;
    
    private InvisibilityController _invisibilityController;

    private void Awake()
    {
        _invisibilityController = GetComponent<InvisibilityController>();
    }

    public void StartInvincibility()
    {
        _invisibilityController.StartInvincibility(invincibilityDuration);
    }
}
