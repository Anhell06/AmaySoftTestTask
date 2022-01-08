using Assets.CodeBase.Infracstructure;
using System.Collections.Generic;

namespace Assets.CodeBase.StaticData
{
    public interface IStaticDataService: IService
    {
        Dictionary<string, Cell> Cells { get; }
        List<FieldData> FieldDatas { get; }
        int LevelCount { get; }

        bool CellIsUsed(Cell cell);
        void MarkCellUsed(Cell cell);
        int GetCurrentLevel();
        void SetNextLevel();
    }
}