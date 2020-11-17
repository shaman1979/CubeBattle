using CubeBattle.Tracks;
using CubeBattle.Units.Enemy;

namespace CubeBattle.Units.Warrior
{
    public class WarriorPush : IUnitPushing
    {
        private readonly Setting setting;

        private float pushBoost;

        private WarriorFacade unitFacade;

        public WarriorPush(Setting setting)
        {
            this.setting = setting;
        }

        public void ApplicationPushBoost(float value)
        {
            pushBoost = value;
        }

        public void EnemyPushing(EnemyFacade enemy)
        {
            //var collisionGroup = enemy.GetCollisionGroup();
            enemy.ApplicationForse(-(setting.PushingForce + pushBoost));
        }

        public float GetForge()
        {
            return setting.PushingForce + pushBoost;
        }

        public void WarriorPushing(WarriorFacade warrior)
        {
            warrior.ApplicationForse(setting.PushingForce + pushBoost);
        }

        [System.Serializable]
        public class Setting
        {
            public float PushingForce;
        }
    }
}
