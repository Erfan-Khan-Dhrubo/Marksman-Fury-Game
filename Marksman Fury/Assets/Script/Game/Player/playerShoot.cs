using UnityEngine;
using UnityEngine.InputSystem;

public class playerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    private bool _fireContinously;
    
    

    // Update is called once per frame
    void Update()
    {
        if (_fireContinously)
        {
            FireBullet();
        }
        
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();

        rigidBody.linearVelocity = bulletSpeed * transform.up;


    }

    private void OnFire(InputValue inputValue)
    {
        _fireContinously = inputValue.isPressed;
    }
}
