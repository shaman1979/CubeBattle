using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Warrior.Factory
{
    public class WarriorPool : MonoPoolableMemoryPool<bool, IMemoryPool, WarriorFacade>
    {
    }

    public class WarriorFactory : PlaceholderFactory<bool, WarriorFacade>
    {
    }
}