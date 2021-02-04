using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.View
{
    public class UnitView : IUnitView, IInitializable
    {
        private const string ColorReferens = "_Color";

        private readonly MeshRenderer unitRender;
        private readonly Setting setting;

        public UnitView(MeshRenderer unitRender, Setting setting)
        {
            this.unitRender = unitRender;
            this.setting = setting;
        }

        public void ChangeColor(Color color)
        {
            unitRender.material.SetColor(ColorReferens, color);
        }

        public void Initialize()
        {
            ChangeColor(setting.unitColor);
        }

        [System.Serializable]
        public class Setting
        {
            public Color unitColor;
        }
    }
}