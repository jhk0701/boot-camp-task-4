using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerLevel))]
[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(PlayerAbility))]
[RequireComponent(typeof(PlayerProperty))]
public class Player : MonoBehaviour
{
    public PlayerConfig config;

    public NavMeshAgent Agent { get; private set; }
    public PlayerLevel Level { get; private set; }
    public PlayerStatus Status { get; private set; }
    public PlayerAbility Ability { get; private set; }
    public PlayerProperty Property { get; private set; }
    
    public Enemy Target { get; set; }
    public PlayerStateMachine stateMachine;
    

    void Awake()
    {
        CharacterManager.Instance.Player = this;

        Agent = GetComponent<NavMeshAgent>();
        Level = GetComponent<PlayerLevel>();
        Status = GetComponent<PlayerStatus>();
        Ability = GetComponent<PlayerAbility>();
        Property = GetComponent<PlayerProperty>();

        stateMachine = new PlayerStateMachine(this);
    }

    void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
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
