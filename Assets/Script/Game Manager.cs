using NUnit.Framework;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Gameplay,
        GameOver,
        LevelUp,
        ScoreS
    }

    public GameState currentState;
    public GameState previouState;

    public bool playing;
    public bool isGameOver;
    private bool activeTime;

    float maxTime = 0.3f;
    float actualTime;

    [Header("UI")]
    public GameObject resultsScreen;

    void Update()
    {
        Countdown(maxTime);

        switch (currentState)
        {
            case GameState.Gameplay:
                break;
            case GameState.GameOver:
                if (!isGameOver)
                {
                    isGameOver = true;
                    DisplayResults();
                }
                break;
            case GameState.LevelUp:
                break;
            case GameState.ScoreS:
                break;

            default:
                Debug.LogWarning("State no existe.");
                break;
        }
    }
    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void Countdown(float maxTime)
    {
        maxTime = actualTime;
        actualTime -= Time.deltaTime;
    }

    public void WinCondition(GameState Gameplay)
    {
        actualTime -= Time.deltaTime;

        if (actualTime <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
        if (actualTime <= 0)
        {
            SceneManager.LoadScene("Victory");
            DisplayResults();
        }
        else
        {
            SceneManager.LoadScene("Defeat");
            DisplayResults();
        }
    }

    void DisplayResults()
    {
        resultsScreen.SetActive(true);
    }

    public void DesableScreen()
    {
        resultsScreen.SetActive(false);
    }
}