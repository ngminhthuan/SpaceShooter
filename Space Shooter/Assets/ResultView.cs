using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    public static ResultView Instance { get; private set; }
    public Text text;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayAgain()
    {
        GameView.Instance.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        // If in the Unity Editor, stop the play mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If in a built version of the game, quit the application
        Application.Quit();
#endif
    }
}
