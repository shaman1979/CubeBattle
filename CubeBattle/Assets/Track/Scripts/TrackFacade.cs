using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;
using CubeBattle.MessageBus;
using CubeBattle.Messages;
using CubeBattle.Units;

namespace CubeBattle.Tracks
{
    [RequireComponent(typeof(BoxCollider))]
    public class TrackFacade : SerializedMonoBehaviour
    {
        [SerializeField]
        private string trackName;

        [Inject]
        private TrackSpawnPoint trackSpawnPoint;

        [Inject]
        private TrackSelectedView trackSelectedView;

        [Inject]
        private UnitsInTrack unitsInTrack;

        [Inject]
        private TrackShake trackShake;

        public string GetTrackName() => trackName;

        public void AddUnit(UnitFacade unit)
        {
            unitsInTrack.AddUnit(unit);
        }

        public void RemoveUnit(UnitFacade unit)
        {
            unitsInTrack.RemoveUnit(unit);
        }

        public Vector3 GetEnemySpawnPoint()
        {
            return trackSpawnPoint.GetEnemySpawnPosition();
        }

        public Vector3 GetWarriorSpawnPoint()
        {
            return trackSpawnPoint.GetWarriorSpawnPosition();
        }

        public void Selection()
        {
            trackSelectedView.Selection();
        }

        public void RemoveSelection()
        {
            trackSelectedView.RemoveSelection();
        }

        public bool HasEnemyPlace()
        {
            if(trackSpawnPoint.HasEnemyPlace())
            {
                return true;
            }

            trackShake.Shake();

            return false;
        }

        public bool HasWarriorPlace()
        {
            if (trackSpawnPoint.HasWarriorPlace())
            {
                return true;
            }

            trackShake.Shake();

            return false;
        }

        private void OnDrawGizmos()
        {
            if (trackSpawnPoint != null)
            {
                DrawStartPoint(trackSpawnPoint.GetWarriorSpawnPosition(), Color.green);
                DrawStartPoint(trackSpawnPoint.GetEnemySpawnPosition(), Color.red);
            }
        }

        private void DrawStartPoint(Vector3 position, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(position, 0.2f);
            Gizmos.color = Color.white;
        }
    }
}