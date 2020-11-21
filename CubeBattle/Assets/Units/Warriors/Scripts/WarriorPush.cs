using CubeBattle.Tracks;
using CubeBattle.Units.Enemy;

namespace CubeBattle.Units.Warrior
{
    public class WarriorPush : IUnitPushing
    {
        private readonly Setting setting;

        private float pushBoost;

        public WarriorPush(Setting setting)
        {
            this.setting = setting;
        }

        public void ApplicationPushBoost(float value)
        {
            if (value >= 0)
                pushBoost = value;
        }

        public void EnemyPushing(EnemyFacade enemy)
        {
            enemy.ApplicationForse(-GetForge());
            enemy.ChangeSpeed(-GetForge());
        }

        public float GetForge()
        {
            return setting.PushingForce + pushBoost;
        }

        public void WarriorPushing(WarriorFacade warrior)
        {
            warrior.ApplicationForse(GetForge());
            warrior.Scaning();
            warrior.ChangeSpeed(GetForge());
        }

        [System.Serializable]
        public class Setting
        {
            public float PushingForce;
        }
    }
}
