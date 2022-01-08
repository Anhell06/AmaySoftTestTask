using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.StaticData
{
    [CreateAssetMenu]
    class LevelsStaticData : ScriptableObject
    {
        [SerializeField]
        private List<FieldData> _levelsStaticDatas;

        public List<FieldData> GetLevelsStaticDatas()
        {
            return _levelsStaticDatas;
        }
    }
}
