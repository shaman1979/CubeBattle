using CubeBattle.Units.Enemy;
using CubeBattle.Units.Warrior;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units
{
    public interface IUnitSensor
    {
        Action<EnemyFacade> DiscoveredEnemy { get; set; }
        Action<WarriorFacade> DiscoveresWarrior { get; set; }

        void Scaning();
    }
}