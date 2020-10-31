using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Cameras.Extension
{
    public static class CameraExtensions
    {
        public static float GetUpBorder() => (Camera.main.orthographicSize * 2) + 1;
        public static float GetDownBorder() => -(Camera.main.orthographicSize * 2);
    }
}