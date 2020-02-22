using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vrBoton : MonoBehaviour {

    public Image backgroundImage;
    public Color NormalColor;
    public Color HighLightColor;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnGazeEnter() {
        backgroundImage.color = HighLightColor;
        print("entra");
    }

    public void OnGazeExit()
    {
        backgroundImage.color = NormalColor;
        print("sale");
    }

    public void Onclick() {
        SceneManager.LoadScene("game");
        Debug.Log("click Recibido");
    }
}
