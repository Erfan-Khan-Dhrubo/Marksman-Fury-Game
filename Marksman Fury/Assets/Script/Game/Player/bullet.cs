using System;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        DestroyWhenOffScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void DestroyWhenOffScreen()
    {
        Vector2 screenPoint = _camera.WorldToScreenPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.y < 0 || screenPoint.x > Screen.width || screenPoint.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
}
