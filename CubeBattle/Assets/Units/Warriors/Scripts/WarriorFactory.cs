using CubeBattle.Tracks;
using CubeBattle.Units.Warrior;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.Factory
{
    public class WarriorPool : MonoPoolableMemoryPool<TrackFacade, IMemoryPool, WarriorFacade>
    {
    }

    public class WarriorFactory : PlaceholderFactory<TrackFacade, WarriorFacade>
    {
    }
}