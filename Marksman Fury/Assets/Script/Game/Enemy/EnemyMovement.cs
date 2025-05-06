using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    
    private Rigidbody2D _rigidbody2D;
    
    private PlayerAwarenessController _playerAwarenessController;
    
    private Vector2 _targetDirection;
    
    private float _changeDirectionCooldown;
    
   
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateDirection();
        RotationTowardsTarget();
        SetVelocity();
    }

    private void UpdateDirection()
    {
        HandleRandomDirectionChange();
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
       
    }
    
    
    private void HandleRandomDirectionChange()
    {
        _changeDirectionCooldown -= Time.deltaTime;
        if (_changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;
            
            _changeDirectionCooldown = Random.Range(1f, 4f);
        }
        
    }

    private void RotationTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        _rigidbody2D.SetRotation(rotation);
    }

    private void SetVelocity()
    { 
        _rigidbody2D.linearVelocity = transform.up * speed;
    }
}
