using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    float tiempo;
    public TMP_Text textoContador;
    private bool gameEnded = false;

    public bool GameEnded
    {
        get { return gameEnded; }
    }

    public void EndGame()
    {
        gameEnded = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!GameEnded)
        {
            tiempo += Time.deltaTime;
            double _ = Math.Round(tiempo, 2);
            textoContador.text = _.ToString();
        }
    }
}
