using UnityEngine;

// 특정 레이어를 감지 하는 기능
[RequireComponent(typeof(SphereCollider))]
public class Detector : MonoBehaviour
{
    SphereCollider _collider;
    [SerializeField] Enemy enemy;
    [SerializeField] LayerMask layerMask;


    void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = enemy.data.detectDistance;
    }


    void OnTriggerEnter(Collider other)
    {
        if (IsMatched(layerMask.value, other.gameObject.layer))
        {
            if (other.gameObject.TryGetComponent(out Player player))
                enemy.Target = player.transform;
        }
    }

    bool IsMatched(int value, int layer)
    {
        return value == ((1 << layer) | value);
    }
}
