using Assets.CodeBase.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CellData : ScriptableObject
{
    [SerializeField]
    private Cell[] _cells;

    public Cell[] Cells => _cells;
}
