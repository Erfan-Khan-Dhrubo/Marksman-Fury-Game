using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ICollectabehaviur _collectabeBehaviour;

    private void Awake()
    {
        _collectabeBehaviour = GetComponent<ICollectabehaviur>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();

        if (player != null)
        {
            _collectabeBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}
