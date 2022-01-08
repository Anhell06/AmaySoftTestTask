using Assets.CodeBase.AssetLoader;
using Assets.CodeBase.StateMachine;
using Assets.CodeBase.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameFactory : IGameFactory
{
    private const float OFFSET = .5f;
    private IStaticDataService _staticData;
    private IAssetProvider _assetProvider;
    private GameObject _square;
    private List<GameObject> objPool = new List<GameObject>();
    private GameObject _trueCell;

    public GameObject TrueCell => _trueCell; 

    public GameFactory(IStaticDataService staticData, IAssetProvider assetProvider)
    {
        _staticData = staticData;
        _assetProvider = assetProvider;
        _square = _assetProvider.Square;
    }

    public void CreateField(int level)
    {
        if (level == _staticData.LevelCount)
        {
            LoadRestart();
            return;
        }

        FieldData field = _staticData.FieldDatas[level];
        for (int x = 0; x < field.Row; x++)
        {
            for (int y = 0; y < field.Column; y++)
            {
                GameObject cell = UnityEngine.Object.Instantiate(_square);
                cell.transform.position =
                    new Vector3((y - field.Column * .5f + OFFSET) * _square.transform.localScale.y * .6f, (x - field.Row * .5f + OFFSET) * _square.transform.localScale.x * .6f);

                objPool.Add(cell);

            }
        }
        if (level == 0)
            FirstCreate();

        FillCell();

    }

    private void FirstCreate()
    {
        foreach (var cell in objPool)
        {
            cell.transform.localScale = Vector3.zero;
            cell.GetComponent<CellMediator>().Bounce();
        }
    }

    private void LoadRestart()
    {
        _assetProvider.RestartScreen.GetComponentInChildren<ButtonScript>().ButtonActive();
    }

    public void ClearField()
    {
        foreach (var cell in objPool)
        {
            UnityEngine.Object.Destroy(cell);
        }
        objPool.Clear();
    }

    public void FillCell()
    {

        Dictionary<string, Cell> cellsData = _staticData.Cells;
        List<Cell> cells = GetRundomCells(cellsData);

        List<Cell> cellsCanTrue = new List<Cell>();
        foreach (Cell cell in cells)
        {
            if (!_staticData.CellIsUsed(cell))
                cellsCanTrue.Add(cell);
        }

        if (cellsCanTrue.Count == 0)
            FillCell();

        Cell trueCell = cellsCanTrue[UnityEngine.Random.Range(0, cellsCanTrue.Count)];
        trueCell.isTrue = true;
        _assetProvider.UIText.GetComponent<Text>().text = $"Find {trueCell.Text}";
        Cell[] finishCells = cellsCanTrue.Union(cells).ToArray();

        InitCells(finishCells);

    }

    private void InitCells(Cell[] cellsArray)
    {
        for (int i = 0; i < objPool.Count; i++)
        {
            var mediator = objPool[i].GetComponent<CellMediator>();
            mediator.UpdateSprite(cellsArray[i].Sprite, cellsArray[i].spriteRotation);
            if (cellsArray[i].isTrue)
            {
                _trueCell = objPool[i];
                _staticData.MarkCellUsed(cellsArray[i]);
                mediator.SetTrue();
            }
        }
    }

    private List<Cell> GetRundomCells(Dictionary<string, Cell> from)
    {
        List<Cell> cells = new List<Cell>();
        List<int> randomNumbers = new List<int>();
        for (int i = 0; i < from.Count; i++)
        {
            randomNumbers.Add(i);
        }

        for (int i = 0; i < objPool.Count; i++)
        {
            int rnd = UnityEngine.Random.Range(0, randomNumbers.Count);
            cells.Add(from.ElementAt(randomNumbers[rnd]).Value);
            cells[i].isTrue = false;
            randomNumbers.RemoveAt(rnd);
        }

        return cells;
    }
}
