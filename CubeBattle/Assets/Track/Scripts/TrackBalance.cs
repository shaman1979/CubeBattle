using CubeBattle.MessageBus;
using CubeBattle.Tracks.Messages;
using CubeBattle.Units;
using CubeBattle.Units.Enemy;
using CubeBattle.Units.Warrior;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Tracks
{
    public class TrackBalance : IInitializable
    {
        private readonly UnitsInTrack unitsInTrack;
        private readonly IPublisher publisher;

        private int warriorPower;
        private int enemyPower;

        public TrackBalance(UnitsInTrack unitsInTrack, [Inject(Id = "Local")] IPublisher publisher)
        {
            this.publisher = publisher;
            this.unitsInTrack = unitsInTrack;
        }

        public event Action<int, int> OnChangeBalance; 

        public void Initialize()
        {
            unitsInTrack.OnUnitAdding += AddPower;
            unitsInTrack.OnUnitRemoved += RemovePower;
        }

        private void ChangeWarriorPower(int power)
        {
            warriorPower += power;
            publisher.Publish(new ChangeBalanceMessage(warriorPower, enemyPower));
        }

        private void ChangeEnemyPower(int power)
        {
            enemyPower += power;
            publisher.Publish(new ChangeBalanceMessage(warriorPower, enemyPower));
        }

        private void AddPower(UnitFacade unitFacade)
        {
            if(HasDisplayingUnitType<EnemyFacade>(unitFacade, out var enemy))
            {
                ChangeEnemyPower(enemy.GetPower());              
            }

            if (HasDisplayingUnitType<WarriorFacade>(unitFacade, out var warrior))
            {
                ChangeWarriorPower(warrior.GetPower());
            }
        }

        private void RemovePower(UnitFacade unitFacade)
        {
            if (HasDisplayingUnitType<EnemyFacade>(unitFacade, out var enemy))
            {
                ChangeEnemyPower(-enemy.GetPower());
            }

            if (HasDisplayingUnitType<WarriorFacade>(unitFacade, out var warrior))
            {
                ChangeWarriorPower(-warrior.GetPower());
            }
        }

        private bool HasDisplayingUnitType<T>(UnitFacade unitFacade, out T unit) where T : class
        {
            if(unitFacade is T)
            {
                unit = unitFacade as T;
                return true;
            }

            unit = null;

            return false;
        }
    }
}