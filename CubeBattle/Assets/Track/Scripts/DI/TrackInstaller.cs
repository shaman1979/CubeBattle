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
        private TrackShake.Setting shakeSetting;

        [SerializeField]
        private MeshRenderer trackMeshRenderer;

        [SerializeField]
        private Transform trackTransform;

        public override void InstallBindings()
        {
            Container.Bind<TrackSpawnPoint>().AsSingle();
            Container.BindInstances(spawnPointSetting);

            Container.Bind<TrackShake>().AsSingle();
            Container.BindInstances(shakeSetting);

            Container.Bind<TrackSelectedView>().AsSingle();
            Container.BindInstances(selectionSetting);

            Container.Bind<UnitsInTrack>().AsSingle();
            Container.BindInterfacesTo<TrackBalance>().AsSingle();

            Container.BindInstances(trackMeshRenderer);
            Container.BindInstances(trackTransform);
        }
    }
}