using CubeBattle.MessageBus;
using CubeBattle.Warrior;
using CubeBattle.Warrior.DI;
using CubeBattle.Warrior.Factory;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private WarriorFacade warrior;

    public override void InstallBindings()
    {
        Container.BindFactory<WarriorFacade, WarriorFactory>()
            .FromPoolableMemoryPool<WarriorFacade, WarriorPool>(binder => binder
            .WithInitialSize(5)
            .FromComponentInNewPrefab(warrior)
            .UnderTransformGroup("Warriors"));

        Container.BindInterfacesTo<MessageBus>().AsSingle();
    }
}