using CubeBattle.Enemy;
using CubeBattle.MessageBus;
using CubeBattle.Tracks;
using CubeBattle.Warrior;
using CubeBattle.Warrior.DI;
using CubeBattle.Warrior.Factory;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private WarriorFacade warrior;

    public override void InstallBindings()
    {
        Container.BindFactory<bool, WarriorFacade, WarriorFactory>()
            .FromPoolableMemoryPool<bool, WarriorFacade, WarriorPool>(binder => binder
            .WithInitialSize(5)
            .FromComponentInNewPrefab(warrior)
            .UnderTransformGroup("Warriors"));

        Container.BindInterfacesAndSelfTo<InstallingWarriorOnRoad>().AsSingle();

        Container.BindInterfacesAndSelfTo<EnemySpawn>().AsSingle();

        Container.Bind<TrackFacade>().FromComponentsInHierarchy().AsSingle();

        Container.BindInterfacesTo<MessageBus>().AsSingle();
    }
}