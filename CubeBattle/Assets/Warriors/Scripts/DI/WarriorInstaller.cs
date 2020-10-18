using UnityEngine;
using Zenject;

namespace CubeBattle.Warrior.DI
{
    public class WarriorInstaller : MonoInstaller
    {
        [SerializeField]
        private WarriorMovening.Setting moveSetting;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WarriorMovening>().AsSingle();
            Container.BindInstance(moveSetting);

            Container.BindInstance(gameObject.transform).WithId("Warrior");
        }
    }
}