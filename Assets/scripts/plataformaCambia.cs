using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class plataformaCambia : MonoBehaviour
{
    public float tiempoMaximo = 4.0f;
    private float tiempoCambio;
    private Color color;
    public bool esBlanco;


    private AudioSource audioSource;
    public AudioClip audioSound;


    // Start is called before the first frame update
    void Start()
    {
        cambioColor(false);
        tiempoCambio = tiempoMaximo;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoCambio = tiempoCambio - Time.deltaTime;
        // Debug.Log("deltaTime: " + Time.deltaTime);

        if (tiempoCambio <= 0) {
            // Debug.Log("Dentro: " + tiempoCambio);

            esBlanco = !esBlanco;
            cambioColor(true);

            tiempoCambio = tiempoMaximo;
        }
    }

    void cambioColor(bool playSound = false) {

        if (playSound) {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioSound;
            audioSource.Play();
        }

        if (esBlanco) {
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0.3f);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            } 
        else {
                gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
    }
}
