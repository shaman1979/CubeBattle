using CubeBattle.Units.Enemy;
using CubeBattle.Units.Warrior;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units
{
    public interface IUnitPushing
    {
        void EnemyPushing(EnemyFacade enemy);
        void WarriorPushing(WarriorFacade warrior);
    }
}