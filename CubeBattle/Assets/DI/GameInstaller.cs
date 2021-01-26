using CubeBattle.MessageBus;
using CubeBattle.Spawners;
using CubeBattle.Tracks;
using CubeBattle.Units.Enemy;
using CubeBattle.Units.Factory;
using CubeBattle.Units.Warrior;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private WarriorFacade warrior;

    [SerializeField]
    private EnemyFacade enemy;

    [SerializeField]
    private EnemySpawn.Setting enemySpawnSetting;

    public override void InstallBindings()
    {
        Container.BindFactory<WarriorFacade, WarriorFactory>()
            .FromPoolableMemoryPool<WarriorFacade, WarriorPool>(binder => binder
            .WithInitialSize(5)
            .FromComponentInNewPrefab(warrior)
            .UnderTransformGroup("Warriors"));

        Container.BindFactory<EnemyFacade, EnemyFactory>()
            .FromPoolableMemoryPool<EnemyFacade, EnemyPool>(binder => binder
            .WithInitialSize(5)
            .FromComponentInNewPrefab(enemy)
            .UnderTransformGroup("Enemyes"));

        Container.BindInterfacesAndSelfTo<InstallingUnitOnRoad>().AsSingle();

        Container.BindInterfacesAndSelfTo<EnemySpawn>().AsSingle();
        Container.BindInstance(enemySpawnSetting);

        Container.Bind<TrackFacade>().FromComponentsInHierarchy().AsSingle();

        Container.BindInterfacesTo<MessageBus>().AsSingle();
    }
}