using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Tracks
{
    public class TrackSelectedView
    {
        private const string ColorReferensName = "_Color";

        private readonly MeshRenderer trackMeshRenderer;
        private readonly Setting setting;

        public TrackSelectedView(MeshRenderer trackMeshRenderer, Setting setting)
        {
            this.trackMeshRenderer = trackMeshRenderer;
            this.setting = setting;
        }

        public void Selection()
        {
            trackMeshRenderer.material.SetColor(ColorReferensName, setting.SelectedColor);
        }

        public void RemoveSelection()
        {
            trackMeshRenderer.material.SetColor(ColorReferensName, setting.NotSelectedColor);
        }

        [System.Serializable]
        public class Setting 
        {
            public Color SelectedColor;
            public Color NotSelectedColor;
        }
    }
}
