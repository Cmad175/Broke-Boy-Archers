using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[DefaultExecutionOrder(-1)]
public class CharacterSpawnManager : MonoBehaviour
{
    [FormerlySerializedAs("playerPrefab")] [SerializeField] GameObject characterPrefab;
    [SerializeField] int playerCount;
    [SerializeField] List<CharacterSO> playerSos;
    [SerializeField] private CharacterSO botSo;
    
    private List<Transform> spawnpoints;

    private void Awake()
    {
        spawnpoints = GetComponentsInChildren<Transform>().ToList();
        spawnpoints.RemoveAt(0);//Gets removed because GetComponentsInChildren Includes the parent object too
    }

    private void Start() => SpawnPlayers();
    
    private void SpawnPlayers()
    {
        //Spawns character prefabs. If it hasn't spawned enough players it adds the player component to the character.
        //If there are enough players it starts adding the bot component.
        for (int i = 0; i < spawnpoints.Count; i++)
        {
            GameObject character = Instantiate(characterPrefab, spawnpoints[i].transform.position, Quaternion.identity);
            if (i < playerCount)
            {   //makes character a player
                character.AddComponent<Player>().SetUpPlayer(playerSos[i]); 
                GameManager.instance.AddCharacter(playerSos[i].characterName);
            }
            else
            {
                //makes character a bot
                character.AddComponent<Bot>().SetUpBot(botSo);
                character.name = $"Bot_{i - playerCount}";
                GameManager.instance.AddCharacter(character.name);
            }
                
        }
        
    }
}
