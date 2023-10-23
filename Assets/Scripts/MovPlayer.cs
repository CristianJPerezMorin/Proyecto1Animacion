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
    public TMP_Text mensaje;
    public AudioSource audio;
    public GameObject pasadizo;
    public Rigidbody2D Trampa;

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
        if(colecionable == 3)
        {
            pasadizo.SetActive(false);
        }

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

        if (transform.position.x >= 22)
        {
            Trampa.gravityScale = 1;
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
            mensaje.text = "Juego Finalizado.";
            gameManager.EndGame();
        }
    }
    private void ResetSpriteColor()
    {
        sprite.color = colorOriginal;
    }

}
