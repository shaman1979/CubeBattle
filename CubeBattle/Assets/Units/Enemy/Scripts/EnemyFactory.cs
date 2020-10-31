using CubeBattle.Units.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.Factory
{
    public class EnemyPool : MonoPoolableMemoryPool<IMemoryPool, EnemyFacade>
    {
    }

    public class EnemyFactory : PlaceholderFactory<EnemyFacade>
    {
    }
}