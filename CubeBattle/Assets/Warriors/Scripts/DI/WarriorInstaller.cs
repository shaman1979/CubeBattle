using UnityEngine;
using Zenject;

namespace CubeBattle.Warrior.DI
{
    public class WarriorInstaller : MonoInstaller
    {
        [SerializeField]
        private WarriorMovening.Setting moveSetting;

        [SerializeField]
        private WarriorBorderChecker.Setting borderSetting;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WarriorMovening>().AsSingle();
            Container.BindInstance(moveSetting);

            Container.BindInterfacesAndSelfTo<WarriorBorderChecker>().AsSingle();
            Container.BindInstance(borderSetting);


            Container.BindInstance(gameObject.transform).WithId("Warrior");
        }
    }
}