using CubeBattle.Units.View.Pool;
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
        private readonly ViewModelPool pool;

        private ModelView currentModelView;

        public UnitView(MeshRenderer unitRender, Setting setting, ViewModelPool pool)
        {
            this.unitRender = unitRender;
            this.setting = setting;
            this.pool = pool;
        }

        public void ChangeColor(Color color)
        {
            unitRender.material.SetColor(ColorReferens, color);
        }

        public void Initialize()
        {
            ChangeColor(setting.unitColor);
        }

        public void ChangeModel(WarriorViewType type)
        {
            if(currentModelView != null)
            {
                pool.Push(currentModelView);
            }

            currentModelView = pool.Pop(type);

            currentModelView.gameObject.SetActive(true);
            currentModelView.transform.SetParent(setting.ParentTransform);
            currentModelView.transform.localPosition = Vector3.zero;
            currentModelView.transform.localRotation = Quaternion.Euler(setting.Rotation);
        }

        [System.Serializable]
        public class Setting
        {
            public Color unitColor;
            public Transform ParentTransform;
            public Vector3 Rotation;
        }
    }
}