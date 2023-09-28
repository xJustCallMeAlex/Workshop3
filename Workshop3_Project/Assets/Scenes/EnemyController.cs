using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    public Transform player;
    public float detectionRange;
    private bool state;
    
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
        Vector3 distanceToPlayer = player.position - transform.position;

        if (state)
        {
            if (distanceToPlayer.magnitude < detectionRange + 5)
            {
                state = true;
                return true;
            }
            else
            {
                state = false;
                return false;
            }
        }
        else
        {
            if (distanceToPlayer.magnitude < detectionRange)
            {
                state = true;
                return true;
            }
            else
            {
                state = false;
                return false;
            }
        }
        
        
    }
}

