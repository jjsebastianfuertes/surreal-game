using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CEJFinal : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Experiencia")
        {
            //ntador++;
            //im.SetTrigger("FadeOut");
            SceneManager.LoadScene("Inicio");
        }

        if (other.gameObject.name == "Juego")
        {
            //ntador++;
            //nim.SetTrigger("FadeOut");
            // if (contador >= 15) {
            SceneManager.LoadSceneAsync("Game");
            // }
        }
    }

    }
