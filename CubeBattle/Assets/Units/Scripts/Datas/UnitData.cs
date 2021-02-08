using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using CubeBattle.Units.View;

namespace CubeBattle.Units.Datas
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Datas/Unit")]
    public class UnitData : SerializedScriptableObject
    {
        [SerializeField, TabGroup("GameOptions")]
        public float Speed { get; private set; }

        [SerializeField, TabGroup("GameOptions")]
        public float Mass { get; private set; }

        [SerializeField, TabGroup("View")]
        public WarriorViewType View { get; private set; }

        [SerializeField, TabGroup("ShopOptions")]
        public GameObject Preview { get; private set; }

        [SerializeField, TabGroup("ShopOptions")]
        public Sprite Icon { get; private set; }
    }
}