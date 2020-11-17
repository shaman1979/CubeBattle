using Zenject;

namespace CubeBattle.Units.Warrior
{
    public class WarriorFacade : UnitFacade, IPoolable<IMemoryPool>
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

            if (forse >= 0)
                pushing.ApplicationPushBoost(forse);
        }
    }
}