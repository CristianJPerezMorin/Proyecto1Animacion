using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TrapActions : MonoBehaviour
{
    Rigidbody2D fisicas;

    private GameManager gameManager;
    public TMP_Text mensaje;

    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            transform.position = new Vector3(24,9,0);
            fisicas.gravityScale = 0;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            mensaje.text = "Has Perdido.";
            gameManager.EndGame();
        }
    }
}
