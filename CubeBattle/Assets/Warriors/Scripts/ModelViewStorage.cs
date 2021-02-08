using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace CubeBattle.Units.View
{
    [CreateAssetMenu(fileName = "ModelViewStorage", menuName = "Storages/ModelViews")]
    public class ModelViewStorage : SerializedScriptableObject
    {
        [SerializeField]
        private Dictionary<WarriorViewType, ModelView> views;

        public ModelView GetModelView(WarriorViewType type)
        {
            if(views.TryGetValue(type, out var model))
            {
                return model;
            }

            Debug.LogError($"Модели для юнита с типом {type.ToString()} не существует!!!");
            return null;
        }
    } 
}