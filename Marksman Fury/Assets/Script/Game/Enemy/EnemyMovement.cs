using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    
    private Rigidbody2D _rigidbody2D;
    
    private PlayerAwarenessController _playerAwarenessController;
    
    private Vector2 _targetDirection;
    
    private float _changeDirectionCooldown;
    
    [SerializeField] private float screenBorder;
    
    private Camera _camera;

    [SerializeField] private float obstacleCheckCircleRadius;
    
    [SerializeField] private float obstacleCheckDistance;
    
    [SerializeField] private LayerMask obstacleLayerMaskMask;

    private RaycastHit2D[] _obstacleCollisions;
    
    private float _obstacleAvoidanceCooldown;
    private Vector2 _obstacleAvoidanceTargetDirection;
    
    
   
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
        _camera = Camera.main;
        _obstacleCollisions = new RaycastHit2D[10];
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
        HandleObstacles();
        PreventEnemyGoingOffScreen();
       
    }
    
    private void PreventEnemyGoingOffScreen()
    {
        Vector2 screenPoint = _camera.WorldToScreenPoint(transform.position);
        
        if ((screenPoint.x < screenBorder && _targetDirection.x < 0) || (screenPoint.x > _camera.pixelWidth - screenBorder && _targetDirection.x > 0))
        {
            _targetDirection = new Vector2(-_targetDirection.x, _targetDirection.y);
        }
        
        if ((screenPoint.y < screenBorder && _targetDirection.y < 0) || (screenPoint.y > (_camera.pixelHeight - screenBorder) && _targetDirection.y > 0))
        {
            _targetDirection = new Vector2(_targetDirection.x, -_targetDirection.y);
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

    // ??
    private void HandleObstacles()
    {
        _obstacleAvoidanceCooldown -= Time.deltaTime;
        
        var contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(obstacleLayerMaskMask);
        
        int numberOfCollisions = Physics2D.CircleCast(transform.position, obstacleCheckCircleRadius , transform.up, contactFilter, _obstacleCollisions, obstacleCheckDistance);

        for (int index = 0; index < numberOfCollisions; index++)
        {
            var obstacleCollision = _obstacleCollisions[index];

            if (obstacleCollision.collider.gameObject == gameObject)
            {
                continue;
            }

            if (_obstacleAvoidanceCooldown <= 0)
            {
                _obstacleAvoidanceTargetDirection = obstacleCollision.normal;
                _obstacleAvoidanceCooldown = 0.5f;
            }
            
            var targetRotation = Quaternion.LookRotation(transform.forward, _obstacleAvoidanceTargetDirection);
            var rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            _targetDirection = rotation * Vector2.up;
            break;
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
