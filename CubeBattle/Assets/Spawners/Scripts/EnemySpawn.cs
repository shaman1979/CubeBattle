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
            if (time > setting.SpawnOffset)
            {
                if (setting.IsRandom)
                    Spawn(trackFacades[Random.Range(0, trackFacades.Count)]);
                else
                    Spawn(trackFacades[setting.TrackNumber]);

                time = 0;
                return;
            }

            time += Time.deltaTime;
        }

        private void Spawn(TrackFacade track)
        {
            publisher.Publish(new EnemyPlaceOnTrackMessages(track));
        }

        [System.Serializable]
        public class Setting
        {
            public float SpawnOffset;

            //Debug values
            public bool IsRandom;
            public int TrackNumber;
        }
    }
}