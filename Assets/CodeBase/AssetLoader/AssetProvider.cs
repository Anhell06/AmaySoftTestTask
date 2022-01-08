﻿using UnityEngine;

namespace Assets.CodeBase.AssetLoader
{
    public class AssetProvider : IAssetProvider
    {
        private GameObject _square;
        private GameObject _UIText;
        private GameObject _restartScreen;
        public GameObject Square => _square;
        public GameObject UIText => _UIText;
        public GameObject RestartScreen => _restartScreen;

        public AssetProvider()
        {
            _square =  Load<GameObject>("Square");
            _UIText = GameObject.Find("UIText");
            _restartScreen = GameObject.Find("Restart");
        }

        public TObject Load<TObject>(string path) where TObject : Object
        {
            return Resources.Load<TObject>(path);
        }

        public TObject[] LoadAll<TObject>(string path) where TObject : Object
        {
            return Resources.LoadAll<TObject>(path);

        }
    }
}