using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "New Player Sprites", menuName = "SO/Player Sprites")]
public class CharacterSO : ScriptableObject
{
    //This SO contains what every character needs. Different Sprites for each character.
    //Different Inputs for players. And the player character's name
    public Sprite walkingSprite;
    public Sprite crossbowSprite;
    public InputAction moveAction;
    public InputAction shootAction;
    public string characterName;
}
