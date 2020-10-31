using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units.Warrior
{
    public class WarriorView : IUnitView
    {
        private const string ColorReferens = "_Color";

        private readonly MeshRenderer warriorRenderer;

        public WarriorView(MeshRenderer warriorRenderer)
        {
            this.warriorRenderer = warriorRenderer;
        }

        public void ChangeColor(Color color)
        {
            warriorRenderer.material.SetColor(ColorReferens, color);
        }
    }
}