using CubeBattle.Units.Datas;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameDatasInstaller", menuName = "Installers/GameDatasInstaller")]
public class GameDatasInstaller : ScriptableObjectInstaller<GameDatasInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<UnitData>().FromScriptableObjectResource("WarriorDatas").AsSingle();
    }
}