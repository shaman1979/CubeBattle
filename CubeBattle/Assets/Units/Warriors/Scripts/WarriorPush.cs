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
        }

        public float GetForge()
        {
            return setting.PushingForce + pushBoost;
        }

        public void WarriorPushing(WarriorFacade warrior)
        {
        }

        [System.Serializable]
        public class Setting
        {
            public float PushingForce;
        }
    }
}
