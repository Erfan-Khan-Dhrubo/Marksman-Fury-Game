using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRbRigidbody2D;
    
    private Vector2 _movement;
    private Vector2 _smoothMovement;
    private Vector2 _smoothMovementVelocity;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float screenBorder;
    
    private Camera _camera;
    private Animator _animator;
    
    private AudioManager _audioManager;

    private void Awake()
    {
        _camera = Camera.main;
        _animator = GetComponent<Animator>();
        _audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        
    }

    private void FixedUpdate()
    {
        SetPlayerMovement();
        RotationInDirectionInput();
        SetAnimation();
    }

    private void SetAnimation()
    {
        bool playerIsMoving = _movement != Vector2.zero;
        
        _animator.SetBool("isMoving", playerIsMoving);
    }

    private void SetPlayerMovement()
    {
        _smoothMovement = Vector2.SmoothDamp(_smoothMovement, _movement, ref _smoothMovementVelocity, 0.1f);
        playerRbRigidbody2D.linearVelocity = _smoothMovement * 5;
        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPoint = _camera.WorldToScreenPoint(transform.position);
        
        if ((screenPoint.x < screenBorder && playerRbRigidbody2D.linearVelocity.x < 0) || (screenPoint.x > _camera.pixelWidth - screenBorder && playerRbRigidbody2D.linearVelocity.x > 0))
        {
            playerRbRigidbody2D.linearVelocity = new Vector2(0, playerRbRigidbody2D.linearVelocity.y);
        }
        
        if ((screenPoint.y < screenBorder && playerRbRigidbody2D.linearVelocity.y < 0) || (screenPoint.y > _camera.pixelHeight -screenBorder && playerRbRigidbody2D.linearVelocity.y > 0))
        {
            playerRbRigidbody2D.linearVelocity = new Vector2(playerRbRigidbody2D.linearVelocity.x, 0);
        }
        
    }

    private void RotationInDirectionInput()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothMovement);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        playerRbRigidbody2D.MoveRotation(rotation);
    }

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    public void PlayDeathSound()
    {
        _audioManager.PlaySfx(_audioManager.gameOverMusic);
    }
}
