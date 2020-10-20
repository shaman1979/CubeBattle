using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;
using CubeBattle.MessageBus;
using CubeBattle.Messages;

namespace CubeBattle.Tracks
{
    [RequireComponent(typeof(BoxCollider))]
    public class TrackFacade : SerializedMonoBehaviour
    {
        [SerializeField]
        private Transform warriorSpawnPoint;

        [SerializeField]
        private Transform enemySpawnPoint;

        [SerializeField]
        private string trackName;

        [Inject]
        private IPublisher publisher;

        public Vector3 GetWarriorSpawnPosition() => warriorSpawnPoint.position;
        public Vector3 GetEnemySpawnPosition() => enemySpawnPoint.position;

        public string GetTrackName() => trackName;

        private void OnMouseDown()
        {
            publisher.Publish(new WarriorPlaceOnTrackMessage(this));            
        }

        private void OnDrawGizmosSelected()
        {
            if(warriorSpawnPoint)
            {
                Gizmos.DrawSphere(GetWarriorSpawnPosition(), 0.1f);
            }

            if (enemySpawnPoint)
            {
                Gizmos.DrawSphere(GetEnemySpawnPosition(), 0.2f);
            }
        }
    }
}