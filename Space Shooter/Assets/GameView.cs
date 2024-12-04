using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public static GameView Instance { get; private set; }
    public Text playerHealthTxt;
    public Text enemyCountTxt;

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
    public void Start()
    {
        PlayerController.Instance.ResetPlayer();
        EnemySpawner.Instance.ResetStage();
        ResultView.Instance.gameObject.SetActive(false);
    }
    public void ReloadView()
    {
        playerHealthTxt.text = "Player Health: " + PlayerController.Instance.PlayerHealth.ToString();
        enemyCountTxt.text = "Enemy Amount: " +  EnemySpawner.Instance.EnemyAmount.ToString();
    }
}
