using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void awake()
    {
        Instance = this;
    }

}
public enum GameState
{
    Victori,Lose
}
