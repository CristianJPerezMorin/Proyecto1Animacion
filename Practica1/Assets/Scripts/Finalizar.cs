using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Finalizar : MonoBehaviour
{
    public TMP_Text mensajeFinalizar;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        mensajeFinalizar.gameObject.SetActive(false);
    }


    void Update()
    {
        if (gameManager.GameEnded)
        {
            mensajeFinalizar.text = "Juego Finalizado";
            mensajeFinalizar.gameObject.SetActive(true);
            
            Time.timeScale = 0;
        }
    }
}
