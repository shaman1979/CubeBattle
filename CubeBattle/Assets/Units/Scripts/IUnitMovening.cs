using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units
{
    public interface IUnitMovening
    {
        float Speed { get; set; }
        void SetSpeed(float speed);
    }
}