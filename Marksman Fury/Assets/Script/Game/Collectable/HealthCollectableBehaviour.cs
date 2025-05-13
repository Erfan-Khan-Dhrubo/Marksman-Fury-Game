using UnityEngine;

public class HealthCollectableBehaviour : MonoBehaviour, ICollectabehaviur
{
    [SerializeField] float healthAmount;
    public void OnCollected(GameObject player)
    {
        player.GetComponent<HealthController>().AddHealth(healthAmount);
    }
}
