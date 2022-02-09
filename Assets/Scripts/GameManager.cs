using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UnityEvent OnGameSetup = new UnityEvent();
    public UnityEvent OnGameStart = new UnityEvent();

    public enum GameState
    {
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        Debug.Log("Press F to start game");
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            SetUpGame();
            StartGame();
        }
    }

    private void SetGameState(GameState gameState)
    {
    }

    private void SetUpGame()
    {
        OnGameSetup?.Invoke();
    }

    private void StartGame()
    {
        OnGameStart?.Invoke();
    }

    private void PauseGame()
    {
    }

    private void NextLevel()
    {
    }

    private void ChangeScene()
    {
    }
}