using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerLevel))]
[RequireComponent(typeof(PlayerStat))]
[RequireComponent(typeof(PlayerProperty))]
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerController controller;
    [HideInInspector] public PlayerLevel level;
    [HideInInspector] public PlayerStat stat;
    [HideInInspector] public PlayerProperty property;
    

    void Awake()
    {
        CharacterManager.Instance.Player = this;

        controller = GetComponent<PlayerController>();
        level = GetComponent<PlayerLevel>();
        stat = GetComponent<PlayerStat>();
        property = GetComponent<PlayerProperty>();
    }
    
}
