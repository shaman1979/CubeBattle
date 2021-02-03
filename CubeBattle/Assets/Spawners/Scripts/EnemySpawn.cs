using CubeBattle.MessageBus;
using CubeBattle.Messages;
using CubeBattle.Tracks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Spawners
{
    public class EnemySpawn : ITickable
    {
        private readonly IPublisher publisher;
        private readonly List<TrackFacade> trackFacades;
        private readonly Setting setting;

        private float time = 0;

        public EnemySpawn(IPublisher publisher, List<TrackFacade> trackFacades, Setting setting)
        {
            this.publisher = publisher;
            this.trackFacades = trackFacades;
            this.setting = setting;
        }

        public void Tick()
        {
            if (!setting.IsRunning)
                return;

            if (time > setting.SpawnOffset)
            {
                var id = setting.IsRandom ? Random.Range(0, trackFacades.Count) : setting.TrackNumber;
                var track = GetTrackFacade(id);

                if (track.HasEnemyPlace())
                {
                    Spawn(GetTrackFacade(id));
                }

                time = 0;
                return;
            }

            time += Time.deltaTime;
        }

        private void Spawn(TrackFacade track)
        {
            publisher.Publish(new EnemyPlaceOnTrackMessage(track));
        }

        private TrackFacade GetTrackFacade(int id)
        {
            return trackFacades[id];
        }

        [System.Serializable]
        public class Setting
        {
            public float SpawnOffset;

            //Debug values
            public bool IsRandom;
            public int TrackNumber;
            public bool IsRunning;
        }
    }
}