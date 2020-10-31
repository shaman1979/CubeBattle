using CubeBattle.Units.Enemy;

namespace CubeBattle.Units.Warrior
{
    public class WarriorPush : IUnitPushing
    {
        private readonly Setting setting;

        public WarriorPush(Setting setting)
        {
            this.setting = setting;
        }

        public void EnemyPushing(EnemyFacade enemyFacade)
        {
            enemyFacade.ApplicationForse(-setting.PushingForce);
        }

        public void WarriorPushing(WarriorFacade warrior)
        {
            warrior.ApplicationForse(setting.PushingForce);
        }

        [System.Serializable]
        public class Setting
        {
            public float PushingForce;
        }
    }
}
