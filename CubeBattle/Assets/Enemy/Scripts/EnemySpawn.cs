using CubeBattle.MessageBus;
using CubeBattle.Messages;
using CubeBattle.Tracks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Enemy
{
    public class EnemySpawn : ITickable
    {
        private readonly IPublisher publisher;
        private readonly List<TrackFacade> trackFacades;

        private float timeOffset = 5f;
        private float time = 0;

        public EnemySpawn(IPublisher publisher, List<TrackFacade> trackFacades)
        {
            this.publisher = publisher;
            this.trackFacades = trackFacades;
        }

        public void Tick()
        {
            if(time > timeOffset)
            {
                publisher.Publish(new EnemyPlaceOnTrackMessages(trackFacades[Random.Range(0, trackFacades.Count)]));
                time = 0;
                return;
            }

            time += Time.deltaTime;
        }
    }
}