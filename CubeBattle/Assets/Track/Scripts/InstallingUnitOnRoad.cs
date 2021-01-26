using CubeBattle.MessageBus;
using CubeBattle.Messages;
using CubeBattle.Units;
using CubeBattle.Units.Factory;
using UnityEngine;
using Zenject;

namespace CubeBattle.Tracks
{
    public class InstallingUnitOnRoad : IInitializable
    {
        private readonly ISubscriber subscriber;
        private readonly WarriorFactory warriorFactory;
        private readonly EnemyFactory enemyFactory;

        public InstallingUnitOnRoad(ISubscriber subscriber, WarriorFactory warriorFactory, EnemyFactory enemyFactory)
        {
            this.subscriber = subscriber;
            this.warriorFactory = warriorFactory;
            this.enemyFactory = enemyFactory;
        }

        public void Initialize()
        {
            subscriber.Subscriber<WarriorPlaceOnTrackMessage>(message =>
            { 
                WarriorPlace(message.TrackFacade, message.TrackFacade.GetWarriorSpawnPosition(), warriorFactory);
            });

            subscriber.Subscriber<EnemyPlaceOnTrackMessage>(message =>
            {
                WarriorPlace(message.TrackFacade, message.TrackFacade.GetEnemySpawnPosition(), enemyFactory);
            });
        }

        private void WarriorPlace<T>(TrackFacade trackFacade, Vector3 spawnPoint, PlaceholderFactory<T>  factory) where T : UnitFacade
        {
            var unit = factory.Create();

            unit.transform.position = spawnPoint;

            Debug.Log($"Создание воина на дороге {trackFacade.GetTrackName()}.");
        }
    }
}