
using System;

namespace CustomData
{
    public class Constants
    {
        // 리소스 로드용 경로들
        public const string PATH_PLAYER_PREFAB = "Prefabs/Player";
        public const string PATH_ENEMY = "Prefabs/Enemies/";

        public const string PATH_IN_GAME_CANVAS = "Prefabs/UI/In Game Canvas";
    }

    [Serializable]
    public class Reward
    {
        public float exp;
        public ulong gold;
        public ulong jewelry;

        // TODO : 아이템 보상
    }
}