using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartView : MonoBehaviour
{
    public void StartGame()
    {
        GameView.Instance.ReloadView();
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
