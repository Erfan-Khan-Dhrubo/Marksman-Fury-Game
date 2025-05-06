using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
