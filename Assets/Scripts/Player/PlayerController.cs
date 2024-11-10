using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public NavMeshAgent Agent { get; private set; }
    public StateMachine stateMachine;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();

        stateMachine = new PlayerStateMachine();
    }
    
}
