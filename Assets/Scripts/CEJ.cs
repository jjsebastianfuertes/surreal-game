using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CEJ : MonoBehaviour {

    public Animator anim;
    int contador = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Juego") {
            contador++;
            anim.SetTrigger("FadeOut");
            SceneManager.LoadScene("T_Inicio-game");
        }

        if (other.gameObject.name == "Experiencia") {
            contador++;
            anim.SetTrigger("FadeOut");
           // if (contador >= 15) {
                SceneManager.LoadSceneAsync(4);
           // }
        }

    }
}
