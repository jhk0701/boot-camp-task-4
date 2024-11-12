using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Detector : MonoBehaviour
{
    SphereCollider _collider;
    [SerializeField] Enemy enemy;
    [SerializeField] LayerMask layerMask;


    void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = CharacterManager.Instance.enemyConfig.detectDistance;
    }


    void OnTriggerEnter(Collider other)
    {
        if (IsMatched(layerMask.value, other.gameObject.layer))
        {
            if (other.gameObject.TryGetComponent(out Player player))
                enemy.Target = player;
        }
    }

    // 추적을 포기하는 건 enemy state에서 처리

    bool IsMatched(int value, int layer)
    {
        return value == (1 << layer | value);
    }
}
