using UnityEngine;

//the Sprite thing is a bit quirky, see the Obstacle script for explanation
[CreateAssetMenu(fileName = "New Obstacle Sprites", menuName = "SO/Obstacle Sprites")]
public class ObstacleSO : ScriptableObject
{
    public int health;
    public Sprite[] sprites;
    public float mass;
}
