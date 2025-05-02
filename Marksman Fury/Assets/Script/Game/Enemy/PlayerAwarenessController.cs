using UnityEngine;
using UnityEngine.UI;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    
    public PlayerMovement playerMovement;
    
    public Vector2 DirectionToPlayer { get; private set; }
    
    [SerializeField] private float playerDistance;
    
     private Transform _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _player = playerMovement.GetComponent<PlayerMovement>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }

    }
}
