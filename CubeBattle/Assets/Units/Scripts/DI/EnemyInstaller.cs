using CubeBattle.Units;
using CubeBattle.Units.Enemy;
using CubeBattle.Units.Movening;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField]
    private UnitMovening.Setting moveSetting;

    [SerializeField]
    private EnemySensor.Setting sensorSetting;

    [SerializeField]
    private EnemyPush.Setting pushSetting;

    [SerializeField]
    private new Rigidbody rigidbody;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<UnitMovening>().AsSingle();
        Container.BindInstance(moveSetting);

        Container.BindInterfacesTo<EnemyView>().AsSingle();

        Container.BindInterfacesTo<EnemySensor>().AsSingle();
        Container.BindInstance(sensorSetting);

        Container.BindInterfacesTo<EnemyPush>().AsSingle();
        Container.BindInstance(pushSetting);

        Container.BindInstance(gameObject.transform).WithId("Unit");

        Container.BindInterfacesAndSelfTo<UnitBorderChecker>().AsSingle();

        Container.BindInstance(rigidbody).WithId("Unit");
    }
}