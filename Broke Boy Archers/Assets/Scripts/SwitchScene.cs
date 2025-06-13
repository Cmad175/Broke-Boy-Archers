using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    //yeah it does what it does
    [SerializeField] private int scene;

    public void SwitchToScene()
    {
        SceneManager.LoadScene(scene);
    }
}
