using UnityEngine;
using UnityEngine.InputSystem;

public class playerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject gunOffset;
    
    [SerializeField] private float timeBetweenShots;
    private float _lastFireTime;

    private bool _fireContinously;

    private bool _fireSingle;
    
    

    // Update is called once per frame
    void Update()
    {
        
        if (_fireContinously || _fireSingle)
        {
            float timeSinceLastShot = Time.time - _lastFireTime;
            if (timeSinceLastShot >= timeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
                _fireSingle = false;
            } 
        }
        
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunOffset.transform.position, transform.rotation);
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();

        rigidBody.linearVelocity = bulletSpeed * transform.up;


    }

    public void OnAttack(InputValue inputValue)
    {
        Debug.Log("Fire");
        _fireContinously = inputValue.isPressed;
    }
    
    
    public void OnAttack1(InputValue inputValue)
    {
        _fireContinously = inputValue.isPressed;
        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }
        
    }
    
    
}
