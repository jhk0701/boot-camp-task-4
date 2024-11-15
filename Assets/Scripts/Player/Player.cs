using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(PlayerAbility))]
public class Player : MonoBehaviour
{
    public CharacterData data;

    public NavMeshAgent Agent { get; private set; }
    public PlayerStatus Status { get; private set; }
    public PlayerAbility Ability { get; private set; }
    
    public Enemy Target { get; set; }
    public PlayerStateMachine stateMachine;

    public UnityEvent<Vector3, Vector3> OnAttack;

    void Awake()
    {
        CharacterManager.Instance.Player = this;

        Agent = GetComponent<NavMeshAgent>();
        Status = GetComponent<PlayerStatus>();
        Ability = GetComponent<PlayerAbility>();

        stateMachine = new PlayerStateMachine(this);
    }

    void Start()
    {
        Initialize();

        Status.OnPlayerDead += () =>
        {
            GameManager.Instance.StageEnd(false);
        };
    }
    
    void Update()
    {
        stateMachine.StateUpdate();
    }

    void FixedUpdate()
    {
        stateMachine.StateFixedUpdate();
    }

    
    void Initialize()
    {
        ProceduralGenerator map = GameManager.Instance.mapGenerator;
        Transform block = map.blockQueue.Dequeue();
        map.blockQueue.Enqueue(block);
        Agent.Warp(block.position);
        
        stateMachine.ChangeState(stateMachine.IdleState);
    }
    
}
