using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    public Player Player { get; set; }

    public List<Enemy> enemies;

    public GameObject CreatePlayer()
    {
        GameObject player = Resources.Load<GameObject>(CustomData.Constants.PATH_PLAYER_PREFAB);
        return Instantiate(player);
    }

    // TODO 최적화 필요
    public Enemy GetNearestEnemy()
    {
        return enemies.Where(n=>!n.IsDead).OrderBy(n => Vector3.SqrMagnitude(n.transform.position - Player.transform.position)).ElementAt(0);
    }
}