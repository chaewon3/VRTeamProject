using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public bool Playing;
    private int Heart = 5;

    public int Life
    {
        get { return Heart; }
        set
        {
            Heart -= value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }
}