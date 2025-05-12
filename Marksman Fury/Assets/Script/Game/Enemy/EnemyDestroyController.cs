using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    public void EnemyDestroy(float delay)
    {
        Destroy(gameObject, delay);
    }
}
