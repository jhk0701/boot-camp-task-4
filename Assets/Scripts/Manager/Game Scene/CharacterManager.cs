using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{

    public Player Player { get; set; }

    public List<Enemy> enemies = new List<Enemy>();


    public GameObject CreatePlayer()
    {
        GameObject player = Resources.Load<GameObject>(CustomData.Constants.PATH_PLAYER_PREFAB);
        return Instantiate(player);
    }

    public void SpawnEnemy(Stage data)
    {
        ProceduralGenerator map = GameManager.Instance.mapGenerator;
        
        for (int i = 0; i < data.enemyGroup.Length; i++)
        {
            Transform block = map.blockQueue.Dequeue();
            map.blockQueue.Enqueue(block);
            
            foreach (var enemy in data.enemyGroup[i].enemies)
            {
                Instantiate(enemy, block.position, Quaternion.identity);
            }
        }
    }

    // TODO : 최적화 필요
    public Enemy GetNearestEnemy()
    {
        var alives = enemies.Where(n=>!n.Status.IsDead);
        if (alives.Count() == 0) return null;

        return alives.OrderBy(n => Vector3.SqrMagnitude(n.transform.position - Player.transform.position)).ElementAt(0);
    }
}