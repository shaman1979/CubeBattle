using CubeBattle.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Tracks
{
    public class CollisionGroup
    {
        private int allForse;
        private List<UnitFacade> units;

        public void AddUnit(UnitFacade unit)
        {
            units.Add(unit);
        }

        public void RemoveUnit(UnitFacade unit)
        {
            units.Remove(unit);
        }

        public void DestroyGroup()
        {
            units.Clear();
        }
    }
}