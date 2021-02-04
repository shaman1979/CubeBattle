using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Messages
{
    public class PlayerBaseHealthChangeMessage
    {
        public int Health;

        public PlayerBaseHealthChangeMessage(int health)
        {
            Health = health;
        }
    }
}