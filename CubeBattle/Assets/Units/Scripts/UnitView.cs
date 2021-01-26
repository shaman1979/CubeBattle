using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units.View
{
    public class UnitView : IUnitView
    {
        private const string ColorReferens = "_Color";

        private readonly MeshRenderer enemyRenderer;

        public UnitView(MeshRenderer enemyRenderer)
        {
            this.enemyRenderer = enemyRenderer;
        }

        public void ChangeColor(Color color)
        {
            enemyRenderer.material.SetColor(ColorReferens, color);
        }
    }
}