using CubeBattle.Tracks;
using CubeBattle.Units.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.Factory
{
    public class EnemyPool : MonoPoolableMemoryPool<TrackFacade, IMemoryPool,  EnemyFacade>
    {
    }

    public class EnemyFactory : PlaceholderFactory<TrackFacade ,EnemyFacade>
    {
    }
}