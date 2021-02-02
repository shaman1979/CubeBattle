using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CubeBattle.Tracks
{
    public class TrackSpawnPoint
    {
        private readonly Setting setting;
        private readonly UnitsInTrack unitsInTrack;

        private float maxDistance = 1f;

        public TrackSpawnPoint(UnitsInTrack unitsInTrack, Setting setting)
        {
            this.setting = setting;
            this.unitsInTrack = unitsInTrack;
        }

        public Vector3 GetWarriorSpawnPosition() => setting.WarriorSpawnPoint.position;
        public Vector3 GetEnemySpawnPosition() => setting.EnemySpawnPoint.position;

        public bool HasWarriorPlace()
        {
            var units = unitsInTrack.GetUnitTravelledPosition();

            return units.All(x => CheckingDistance(x, GetWarriorSpawnPosition().z));
        }

        public bool HasEnemyPlace()
        {
            var units = unitsInTrack.GetUnitTravelledPosition();

            return units.All(x => CheckingDistance(x, GetEnemySpawnPosition().z));
        }

        private bool CheckingDistance(float unit, float spawnPoint)
        {
            return Mathf.Abs(unit - spawnPoint) > maxDistance;
        }

        [System.Serializable]
        public class Setting
        {
            public Transform WarriorSpawnPoint;
            public Transform EnemySpawnPoint;
        }
    }
}