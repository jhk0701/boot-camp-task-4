
using System;

namespace CustomData
{
    public class Constants
    {
        // 리소스 로드용 경로들
        public const string PATH_PLAYER_PREFAB = "Prefabs/Player";
        public const string PATH_ENEMY = "Prefabs/Enemies/";

        public const string PATH_IN_GAME_CANVAS = "Prefabs/UI/In Game Canvas";
        public const string PATH_UI_REGISTER = "Prefabs/UI/UI Register";

        // 씬 이름
        public const string SCENE_START = "StartScene";
        public const string SCENE_MENU = "MenuScene";
        public const string SCENE_GAME = "GameScene";
        
        // 인벤토리
        public const int INVENTORY_MAX_SIZE = 49;
    }

    [Serializable]
    public class Reward
    {
        public float exp;
        public ulong gold;
        public ulong jewelry;

        // TODO : 아이템 보상
        public ItemData[] items;
    }

    [Serializable]
    public class JsonDictionary<TKey, TValue>
    {
        public TKey key;
        public TValue value;
    }
}