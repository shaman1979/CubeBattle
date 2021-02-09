using CubeBattle.MessageBus;
using CubeBattle.Messages;
using CubeBattle.Units;
using CubeBattle.Units.Datas;
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
                WarriorPlace(message.TrackFacade, message.TrackFacade.GetWarriorSpawnPoint(), warriorFactory, message.Data);
            });

            subscriber.Subscriber<EnemyPlaceOnTrackMessage>(message =>
            {
                WarriorPlace(message.TrackFacade, message.TrackFacade.GetEnemySpawnPoint(), enemyFactory, message.Data);
            });
        }

        private void WarriorPlace<T>(TrackFacade trackFacade, Vector3 spawnPoint, PlaceholderFactory<TrackFacade, T> factory, UnitData data) where T : UnitFacade
        {
            var unit = factory.Create(trackFacade);
            unit.Setup(data);
            trackFacade.AddUnit(unit);
            unit.transform.position = spawnPoint;

        }
    }
}