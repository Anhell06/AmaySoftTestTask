using UnityEngine;

[CreateAssetMenu]
public class CellColections : ScriptableObject
{
    [SerializeField]
    private CellData[] _cellCollections;

    public CellData[] CellCollections => _cellCollections;
}
