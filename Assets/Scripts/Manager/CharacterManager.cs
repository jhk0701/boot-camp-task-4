using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    public Player Player { get; set; }

    public GameObject CreatePlayer()
    {
        //TODO : 매직 키워드 제거
        GameObject player = Resources.Load<GameObject>("Prefabs/Player");
        return Instantiate(player);
    }
}