using Assets.CodeBase.Infracstructure;
using UnityEngine;

public interface IGameFactory : IService
{
    GameObject TrueCell { get; }

    void ClearField();
    void CreateField(int level);
}