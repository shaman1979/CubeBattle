using UnityEngine;
using Zenject;

namespace CubeBattle.Tracks.DI
{
    public class TrackInstaller : MonoInstaller
    {
        [SerializeField]
        private TrackSpawnPoint.Setting spawnPointSetting;

        [SerializeField]
        private TrackSelectedView.Setting selectionSetting;

        [SerializeField]
        private MeshRenderer trackMeshRenderer;

        public override void InstallBindings()
        {
            Container.Bind<TrackSpawnPoint>().AsSingle();
            Container.BindInstances(spawnPointSetting);


            Container.Bind<TrackSelectedView>().AsSingle();
            Container.BindInstances(selectionSetting);

            Container.BindInstances(trackMeshRenderer);
        }
    }
}