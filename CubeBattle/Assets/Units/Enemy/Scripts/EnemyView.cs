using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units.Enemy
{
    public class EnemyView : IUnitView
    {
        private const string ColorReferens = "_Color";

        private readonly MeshRenderer enemyRenderer;

        public EnemyView(MeshRenderer enemyRenderer)
        {
            this.enemyRenderer = enemyRenderer;
        }

        public void ChangeColor(Color color)
        {
            enemyRenderer.material.SetColor(ColorReferens, color);
        }
    }
}