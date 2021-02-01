using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Tracks
{
    public class TrackSpawnPoint
    {
        private readonly Setting setting;

        public TrackSpawnPoint(Setting setting)
        {
            this.setting = setting;
        }

        public Vector3 GetWarriorSpawnPosition() => setting.WarriorSpawnPoint.position;
        public Vector3 GetEnemySpawnPosition() => setting.EnemySpawnPoint.position;

        [System.Serializable]
        public class Setting
        {
            public Transform WarriorSpawnPoint;
            public Transform EnemySpawnPoint;
        }
    }
}