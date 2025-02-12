using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class pasarNivel : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioSound;

    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioSound;
            audioSource.Play();

            Debug.Log("Pasando nivel ...");
            int numeroNivel = SceneManager.GetActiveScene().buildIndex + 1;

            col.gameObject.GetComponent<CharacterController2D>().blockPlayer();
            GameObject.Find("levelCompletedLabel2").GetComponent<Text>().enabled = true;
            GameObject.Find("levelCompletedLabel2").GetComponent<Text>().text = String.Format("Level {0} completed!", numeroNivel);

            yield return new WaitForSeconds(1.0f);
            GameObject.Find("levelCompletedLabel2").GetComponent<Text>().enabled = false;

            if (numeroNivel > 2) {
                GameObject.Find("levelCompletedLabel2").GetComponent<Text>().text = "Congrats!!! You've finished the game ... Jam ;-)";
                GameObject.Find("levelCompletedLabel2").GetComponent<Text>().enabled = true;
                yield return new WaitForSeconds(10.0f);
                numeroNivel = 0;
            }

            SceneManager.LoadSceneAsync(numeroNivel);
        }
    }
}
