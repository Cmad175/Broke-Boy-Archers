using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private TMP_Text winnerText;
    
    private Canvas canvas;
    private List<string> _characterNames;
    
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
        
        _characterNames = new List<string>();
        canvas = FindAnyObjectByType<Canvas>();
        canvas.gameObject.SetActive(false);
    }
    
    public void AddCharacter(string characterName) => _characterNames.Add(characterName);
    public void RemovePlayer(string playerName)
    {
        _characterNames.Remove(_characterNames.Find(name => name == playerName));

        if (_characterNames.Count == 1)
        {
            FinishGame(_characterNames[0]);
        }
    }

    private void FinishGame(string playerName)
    {
        winnerText.text = $"{playerName} Won!";
        canvas.gameObject.SetActive(true);
    }
}
