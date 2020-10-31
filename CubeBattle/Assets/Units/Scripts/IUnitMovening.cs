using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units
{
    public interface IUnitMovening
    {
        void ChangeSpeed(float newSpeed);
    }
}