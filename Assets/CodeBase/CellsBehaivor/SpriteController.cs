using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public void UpdateSprite(Sprite sprite, float spriteRotation)
    {
        _spriteRenderer.sprite = sprite;
        if (spriteRotation != 0)
            transform.Rotate(0f, 0f, spriteRotation);
    }
}
