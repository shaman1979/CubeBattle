using CubeBattle.Units;
using CubeBattle.Units.Enemy;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField]
    private EnemyMovening.Setting moveSetting;

    [SerializeField]
    private EnemySensor.Setting sensorSetting;

    [SerializeField]
    private EnemyPush.Setting pushSetting;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<EnemyMovening>().AsSingle();
        Container.BindInstance(moveSetting);

        Container.BindInterfacesTo<EnemyView>().AsSingle();

        Container.BindInterfacesTo<EnemySensor>().AsSingle();
        Container.BindInstance(sensorSetting);

        Container.BindInterfacesTo<EnemyPush>().AsSingle();
        Container.BindInstance(pushSetting);

        Container.BindInstance(gameObject.transform).WithId("Unit");

        Container.BindInterfacesAndSelfTo<UnitBorderChecker>().AsSingle();
    }
}