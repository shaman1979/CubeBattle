using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace CubeBattle.Tracks
{
    [RequireComponent(typeof(BoxCollider))]
    public class TrackFacade : SerializedMonoBehaviour
    {
        [SerializeField]
        private Transform spawnPoint;

        [SerializeField]
        private string trackName;

        public Vector3 GetSpawnPosition() => spawnPoint.position;

        private void OnMouseDown()
        {
            Debug.Log($"Создание воина на дороге {trackName} по координате {GetSpawnPosition()}");
        }
    }
}