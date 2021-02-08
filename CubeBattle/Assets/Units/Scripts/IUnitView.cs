using CubeBattle.Units.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units
{
    public interface IUnitView
    {
        void ChangeColor(Color color);
        void ChangeModel(WarriorViewType model);
    }
}