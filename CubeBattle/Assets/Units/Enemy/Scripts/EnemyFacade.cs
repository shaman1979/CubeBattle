using CubeBattle.Tracks;
using Zenject;

namespace CubeBattle.Units.Enemy
{
    public class EnemyFacade : UnitFacade, IPoolable<TrackFacade, IMemoryPool>
    {
        public void OnDespawned()
        {
            pool = null;
            track.RemoveUnit(this);
        }

        public void OnSpawned(TrackFacade trackFacade, IMemoryPool memoryPool)
        {
            pool = memoryPool;
            track = trackFacade;
        }
    }
}