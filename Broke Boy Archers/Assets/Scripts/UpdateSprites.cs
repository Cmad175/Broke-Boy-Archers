using UnityEngine;

public class UpdateSprites : MonoBehaviour
{
    //This script listens for events, these events are when this character picks up an arrow and shoots.
    //When those events occur it switches the sprites out to the appropriate sprite.
    private SpriteRenderer _spriteRenderer;
    private CharacterSO _character;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void AddSpritesSo(CharacterSO characterSo)
    {
        _character = characterSo;
        _spriteRenderer.sprite = _character.walkingSprite;
    }

    public void SwitchToCrossbowSprite() => _spriteRenderer.sprite = _character.crossbowSprite;
    public void SwitchToWalkingSprite() => _spriteRenderer.sprite = _character.walkingSprite;
    
}