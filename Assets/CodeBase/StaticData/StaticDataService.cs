using Assets.CodeBase.AssetLoader;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private IAssetProvider _assetProvider;
        private int _currentLevel = 0;
        private List<Cell> _isBeenTrue = new List<Cell>();
        public int LevelCount { get; private set; }
        public List<FieldData> FieldDatas { get; private set; }
        public Dictionary<string, Cell> Cells { get; private set; }

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            LoadLevel();
            LoadCell();

        }
        public bool CellIsUsed(Cell cell)
        {
            return _isBeenTrue.Contains(cell);
        }
        public void MarkCellUsed(Cell cell)
        {
            _isBeenTrue.Add(cell);
        }

        private void LoadCell()
        {
            var cellCollections = _assetProvider.Load<CellColections>("Cell Colections").CellCollections;
            Cell[] cells = cellCollections[Random.Range(0, cellCollections.Length)].Cells;
            Cells = cells.ToDictionary(x => x.Text);
            Debug.Log(Cells.Count);
        }

        private void LoadLevel()
        {
            FieldDatas = _assetProvider.Load<LevelsStaticData>("LevelData").GetLevelsStaticDatas();
            LevelCount = FieldDatas.Count;
        }

        public int GetCurrentLevel()
        {
            return _currentLevel;
        }

        public void SetNextLevel()
        {
            if (_currentLevel >= LevelCount)
            {
                
                _currentLevel = 0;
            }
            else
            {
                _currentLevel++;
            }
        }
    }
}
