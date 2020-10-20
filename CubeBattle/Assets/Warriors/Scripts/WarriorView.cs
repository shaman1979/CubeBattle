using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Warrior
{
    public class WarriorView
    {
        private const string ColorReferens = "_Color";

        private readonly Setting setting;
        private readonly MeshRenderer warriorRenderer;

        public WarriorView(Setting setting, MeshRenderer warriorRenderer)
        {
            this.setting = setting;
            this.warriorRenderer = warriorRenderer;
        }

        public void ChangeWarriorColor()
        {
            ChangeColor(setting.warriorColor);
        }

        public void ChangeEnemyColor()
        {
            ChangeColor(setting.enemyColor);
        }

        private void ChangeColor(Color color)
        {
            warriorRenderer.material.SetColor(ColorReferens, color);
        }

        [System.Serializable]
        public class Setting
        {
            public Color warriorColor;
            public Color enemyColor;
        }
    }
}