using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class Enemy : MonoBehaviour
{
    public EnemyData data;

    public NavMeshAgent Agent { get; private set; }
    public EnemyStatus Status { get; private set; }

    public EnemyStateMachine stateMachine;

    Transform _target;
    public Transform Target 
    { 
        get => _target; 
        set 
        {
            _target = value;
            OnTargetDetected?.Invoke();
        } 
    }
    public event Action OnTargetDetected;


    void Awake()
    {
        CharacterManager.Instance.enemies.Add(this);

        Agent = GetComponent<NavMeshAgent>();
        Status = GetComponent<EnemyStatus>();

        stateMachine = new EnemyStateMachine(this);
    }

    private void Start()
    {
        Status.OnDead += () =>
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            Destroy(gameObject);
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
}