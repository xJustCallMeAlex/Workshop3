using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyStates currentState;
    
    // Enemy settings.
    public float moveSpeed = 3.0f;
    private Transform _playerTransform;

    public enum EnemyStates
    {
        Idle,
        Chase
    }

    public void SetState(EnemyStates newState)
    {
        currentState = newState;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetState(EnemyStates.Idle);
    }

    void UpdateState()
    {
        // Update logic for each state
        switch (currentState)
        {
            case EnemyStates.Idle:
                UpdateIdleState();
                break;
            case EnemyStates.Chase:
                UpdateChaseState();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    void UpdateIdleState()
    {
        
    }

    void UpdateChaseState()
    {
        // Calculate the direction from the enemy to the player
        Vector3 moveDirection = (_playerTransform.position - transform.position).normalized;

        // Use MoveTowards to move the enemy towards the player
        Vector3 targetPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed
            * Time.deltaTime);
    }
}
