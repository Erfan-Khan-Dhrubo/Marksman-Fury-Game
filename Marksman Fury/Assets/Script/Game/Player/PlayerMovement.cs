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

    private void FixedUpdate()
    {
        SetPlayerMovement();
        RotationInDirectionInput();
    }

    private void SetPlayerMovement()
    {
        _smoothMovement = Vector2.SmoothDamp(_smoothMovement, _movement, ref _smoothMovementVelocity, 0.1f);
        playerRbRigidbody2D.linearVelocity = _smoothMovement * 5;
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
}
