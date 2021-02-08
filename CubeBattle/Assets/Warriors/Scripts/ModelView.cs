using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units.View
{
    public class ModelView : MonoBehaviour
    {
        [SerializeField]
        private WarriorViewType type;

        public WarriorViewType Type => type;
    }
}