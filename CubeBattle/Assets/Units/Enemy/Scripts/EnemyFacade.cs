using CubeBattle.Messages;
using CubeBattle.Tracks;
using Zenject;

namespace CubeBattle.Units.Enemy
{
    public class EnemyFacade : UnitFacade, IPoolable<TrackFacade, IMemoryPool>
    {
        public void OnDespawned()
        {
            pool = null;
        }

        public void OnSpawned(TrackFacade trackFacade, IMemoryPool memoryPool)
        {
            pool = memoryPool;
            track = trackFacade;
        }

        protected override void OnCollisionBorder(UnitBorderChecker.BorderType borderType)
        {
            if(borderType.Equals(UnitBorderChecker.BorderType.PlayerBase))
            {
                publisher.Publish(new DealingPlayerBaseMessage(GetPower()));
            }

            Destroy();
        }
    }
}