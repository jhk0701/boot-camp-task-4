using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerLevel))]
[RequireComponent(typeof(PlayerStat))]
[RequireComponent(typeof(PlayerProperty))]
public class Player : MonoBehaviour
{
    public PlayerConfig config;
    public PlayerController Controller { get; private set; }
    public PlayerLevel Level { get; private set; }
    public PlayerStat Stat { get; private set; }
    public PlayerProperty Property { get; private set; }

    
    public Enemy Target { get; set; }
    
    

    void Awake()
    {
        CharacterManager.Instance.Player = this;

        Controller = GetComponent<PlayerController>();
        Level = GetComponent<PlayerLevel>();
        Stat = GetComponent<PlayerStat>();
        Property = GetComponent<PlayerProperty>();
    }
    
}
