using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public NavMeshAgent Agent { get; private set; }
    public PlayerStateMachine stateMachine;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();

        stateMachine = new PlayerStateMachine(GetComponent<Player>());
    }
    
    void Update()
    {
        stateMachine.StateUpdate();
    }

    void FixedUpdate()
    {
        stateMachine.StateFixedUpdate();
    }
}
