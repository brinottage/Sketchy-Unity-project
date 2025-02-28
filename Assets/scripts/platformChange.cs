using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class plataformaCambia : MonoBehaviour
{
    public float maxTime = 4.0f;
    private float timeChange;
    private Color color;
    public bool isWhite;


    private AudioSource audioSource;
    public AudioClip audioSound;


    // Start is called before the first frame update
    void Start()
    {
        cambioColor(false);
        timeChange = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeChange = timeChange - Time.deltaTime;
        // Debug.Log("deltaTime: " + Time.deltaTime);

        if (timeChange <= 0) {
            // Debug.Log("Dentro: " + tiempoCambio);

            isWhite = !isWhite;
            cambioColor(true);

            timeChange = maxTime;
        }
    }

    void cambioColor(bool playSound = false) {

        if (playSound) {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioSound;
            audioSource.Play();
        }

        if (isWhite) {
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0.3f);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            } 
        else {
                gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
    }
}
