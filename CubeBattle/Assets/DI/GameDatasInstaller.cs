using CubeBattle.Units.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameDatasInstaller", menuName = "Installers/GameDatasInstaller")]
public class GameDatasInstaller : ScriptableObjectInstaller<GameDatasInstaller>
{
    [SerializeField]
    private string unitDatasPath = "WarriorDatas";

    public override void InstallBindings()
    {
        Container.Bind<IEnumerable<UnitData>>().FromMethod(binder =>
        {
            return new List<UnitData>(Resources.LoadAll<UnitData>(unitDatasPath));
        }).AsCached();
    }
}