using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChange;
    private void Awake()//constructor del game manager
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateGameState(GameState.selectoColor);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.selectoColor:
                HandleSelectColor();
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutofRangeException(nameof(newState), newState, null);
        }
        OnGameStateChange?.Invoke(newState);
    }

    private void HandleSelectColor()
    {
        throw new NotImplementedException();
    }
}
public enum GameState
{
    selectoColor,Lose
}
