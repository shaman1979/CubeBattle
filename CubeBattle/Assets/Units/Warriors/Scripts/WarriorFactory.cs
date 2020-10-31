using CubeBattle.Units.Warrior;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.Factory
{
    public class WarriorPool : MonoPoolableMemoryPool<IMemoryPool, WarriorFacade>
    {
    }

    public class WarriorFactory : PlaceholderFactory<WarriorFacade>
    {
    }
}