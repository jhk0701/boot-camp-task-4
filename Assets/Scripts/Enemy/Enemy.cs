using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class Enemy : MonoBehaviour
{
    public EnemyData data;

    public NavMeshAgent Agent { get; private set; }
    public EnemyStatus Status { get; private set; }

    public Player Target { get; set; }
    public EnemyStateMachine stateMachine;


    void Awake()
    {
        CharacterManager.Instance.enemies.Add(this);

        Agent = GetComponent<NavMeshAgent>();
        Status = GetComponent<EnemyStatus>();

        stateMachine = new EnemyStateMachine(this);
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