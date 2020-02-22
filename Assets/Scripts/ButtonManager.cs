using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    //public GameObject btExperiencia;
    

    //public GameObject btJuego;
   

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTrigerEnter(Collider other)
    {

        if(other.gameObject.name == "Experiencia")
        {
            Debug.Log("Cargar1");
            SceneManager.LoadScene("T_inicio-primeraEscena");
        }

        if (other.gameObject.name == "Juego")
        {
            SceneManager.LoadScene("T_Inicio-game");
        }

    }
}
