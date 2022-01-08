using Assets.CodeBase.Infracstructure;
using UnityEngine;

namespace Assets.CodeBase.AssetLoader
{
    public interface IAssetProvider : IService
    {
        GameObject Square { get; }
        GameObject UIText { get; }
        GameObject RestartScreen { get; }

        TObject Load<TObject>(string path) where TObject : Object;
        TObject[] LoadAll<TObject>(string path) where TObject : Object;

    }
}