using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarGameT : MonoBehaviour {

    // Use this for initialization
    void Start() {
        StartCoroutine(DelayLoadLevel());
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator DelayLoadLevel() {
        yield return new WaitForSeconds(14);
        print("cambiar escena");
        SceneManager.LoadSceneAsync("segundaEscena");
    }
}
