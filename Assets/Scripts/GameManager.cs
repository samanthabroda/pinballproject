using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    public GameObject gameOvUI;
    public GameObject mainUI;
    public GameObject restartbttn;
    
    public static GameManager Instance;
    public GameState gameState;
    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameObjects();
        UpdateGameState(GameState.Start);
    }

    private void UpdateGameObjects()
    {
        if (restartbttn == null)
            restartbttn = GameObject.FindGameObjectWithTag("RestartGameBtn");
    }

    public void UpdateGameState(GameState newState)
    {
        UpdateGameObjects();
        OnGameStateChanged?.Invoke(newState);
        gameState = newState;
        switch (newState)
        {
            case GameState.Start:
                gameState = GameState.Start;
                mainUI.SetActive(true);
                gameOvUI.SetActive(false);
                break;
            case GameState.GameOver:
                gameOvUI.SetActive(true);
                mainUI.SetActive(false);
                break;
        }
    }

    private void FixedUpdate()
    {
        scoreText.SetText("Current Score:" + score);
    }
    

}

public enum GameState
{
    Start,
    GameOver
}