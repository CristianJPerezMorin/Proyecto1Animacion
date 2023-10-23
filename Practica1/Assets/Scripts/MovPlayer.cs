using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MovPlayer : MonoBehaviour
{
    Rigidbody2D fisicas;
    SpriteRenderer sprite;

    public float movX, movY, magnitudVelocidad;
    public float colecionable;
    private bool detener;
    private float tiempoDetenido;
    private float tiempoColision;

    private Color colorOriginal;
    public TMP_Text textoColeccionable;
    public AudioSource audio;

    private GameManager gameManager;

    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();
        sprite = GetComponent <SpriteRenderer>();
        audio = GameObject.Find("SonidoRecoger").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        detener = false;
        colecionable = 0;
        magnitudVelocidad = 5;
        tiempoDetenido = 2.0f;
        colorOriginal = sprite.color;
    }

    void Update()
    {
        if (detener && Time.time - tiempoColision >= tiempoDetenido)
        {
            detener = false;
            ResetSpriteColor();
        }

        if (!detener)
        {
            movX = Input.GetAxis("Horizontal");
            movY = Input.GetAxis("Vertical");
            Vector2 movimiento = new Vector2(movX, movY);

            fisicas.velocity = movimiento * magnitudVelocidad;
        }
        else
        {
            fisicas.velocity = Vector2.zero;
        }
        textoColeccionable.text = colecionable.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            sprite.color = Color.red;
            detener = true;
            tiempoColision = Time.time;
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            audio.Play();
            colecionable++;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.EndGame();
        }
    }
    private void ResetSpriteColor()
    {
        sprite.color = colorOriginal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
