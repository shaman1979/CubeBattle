using CubeBattle.Tracks;
using Zenject;

namespace CubeBattle.Units.Warrior
{
    public class WarriorFacade : UnitFacade, IPoolable<TrackFacade, IMemoryPool>
    {
        public void OnDespawned()
        {
            pool = null;
            track.RemoveUnit(this);
        }

        public void OnSpawned(TrackFacade track, IMemoryPool memoryPool)
        {
            pool = memoryPool;
            this.track = track;
        }
    }
}