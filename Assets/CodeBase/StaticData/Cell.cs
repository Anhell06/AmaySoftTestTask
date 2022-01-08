using UnityEngine;

namespace Assets.CodeBase.StaticData
{
    [CreateAssetMenu]
    public class Cell : ScriptableObject
    {
        public string Text;
        public Sprite Sprite;
        public float spriteRotation;

        [HideInInspector]
        public bool isTrue = false;

    }
}
