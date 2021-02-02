using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace CubeBattle.Tracks
{
    public class TrackShake
    {
        private readonly Transform track;
        private readonly Setting setting;

        public TrackShake(Transform track, Setting setting)
        {
            this.track = track;
            this.setting = setting;
        }

        public void Shake()
        {
            track.DOShakePosition(setting.Duration, new Vector3(0.1f, 0, 0));
        }

        [System.Serializable]
        public class Setting
        {
            public float Duration;
        }
    }
}