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
        private Transform spawnPoint;

        [SerializeField]
        private string trackName;

        [Inject]
        private IPublisher publisher;

        public Vector3 GetSpawnPosition() => spawnPoint.position;

        public string GetTrackName() => trackName;

        private void OnMouseDown()
        {
            publisher.Publish(new WarriorPlaceOnTrackMessage(this));            
        }
    }
}