using CubeBattle.Units.Warrior;
using Zenject;

namespace CubeBattle.Units.Enemy
{
    public class EnemyFacade : UnitFacade, IPoolable<IMemoryPool>
    {
        [Inject]
        private UnitBorderChecker borderChecker;

        [Inject]
        private IUnitMovening enemyMovening;

        [Inject]
        private IUnitView enemyView;

        [Inject]
        private IUnitSensor enemySensor;

        private IMemoryPool pool;

        private void Awake()
        {
            borderChecker.WentToBorder += Destroy;
        }

        public void OnDespawned()
        {
            pool = null;
        }

        public void OnSpawned(IMemoryPool memoryPool)
        {
            pool = memoryPool;
        }
        private void Destroy()
        {
            pool.Despawn(this);
        }
    }
}