using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool Playing;
    public int Heart = 5;

    private void Awake()
    {
        Instance = this;
    }
}
