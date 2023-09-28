using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDetected())
        {
            stateMachine.SetState(EnemyStateMachine.EnemyStates.Chase);
        }
        else
        {
            stateMachine.SetState(EnemyStateMachine.EnemyStates.Idle);
        }
    }
    bool PlayerDetected()
    {
        // Implement logic to check if the player is detected
        // (e.g., use raycasting, triggers, etc.)
        return true; // Replace with your detection logic
    }
}

