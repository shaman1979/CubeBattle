using Zenject;

namespace CubeBattle.Units.Enemy
{
    public class EnemyFacade : UnitFacade, IPoolable<IMemoryPool>
    {
        public void OnDespawned()
        {
            pool = null;
        }

        public void OnSpawned(IMemoryPool memoryPool)
        {
            pool = memoryPool;
        }

        public override void ApplicationForse(float forse)
        {
            movening.ChangeSpeed(forse);
        }
    }
}