using CubeBattle.MessageBus;
using CubeBattle.Messages;
using CubeBattle.Warrior.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Tracks
{
    public class InstallingWarriorOnRoad : IInitializable
    {
        private readonly ISubscriber subscriber;
        private readonly WarriorFactory warriorFactory;

        public InstallingWarriorOnRoad(ISubscriber subscriber, WarriorFactory warriorFactory)
        {
            this.subscriber = subscriber;
            this.warriorFactory = warriorFactory;
        }

        public void Initialize()
        {
            subscriber.Subscriber<WarriorPlaceOnTrackMessage>(message =>
            { 
                WarriorPlace(message.TrackFacade); });
        }

        private void WarriorPlace(TrackFacade trackFacade)
        {
            var warrior = warriorFactory.Create();

            warrior.transform.position = trackFacade.GetSpawnPosition();

            Debug.Log($"Создание воина на дороге {trackFacade.GetTrackName()}.");
        }
    }
}