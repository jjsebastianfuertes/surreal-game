using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butones : MonoBehaviour {

	public GameObject menuCanvas;
	public GameObject creditosCanvas;

	public GameObject btEmpezar;
    public GameObject btEmpezar2;
    public GameObject btJugar;
    public GameObject btJugar2;
    public GameObject btCreditos;
    public GameObject btCreditos2;

    public GameObject btBack;
    public GameObject btBack2;

    public Transform cam;
    //public GameObject btExitClaro; 

	// Use this for initialization
	void Start () {

	creditosCanvas.gameObject.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 forward = cam.transform.TransformDirection (Vector3.forward) * 10;
        Debug.DrawRay (cam.position, forward * 15f, Color.blue);
        Ray ray = new Ray (cam.position, forward);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 10000f)) {
            //Debug.Log (hit.transform.gameObject.name);

            if (hit.transform.gameObject.name == "Empezar") {
                
				btEmpezar.gameObject.SetActive (false);
				btEmpezar2.gameObject.SetActive (true);

				if (/* OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)||*/ Input.GetMouseButtonDown(0)) {
                    SceneManager.LoadScene("Escenatal");
                }
            } else {

				btEmpezar.gameObject.SetActive (true);
				btEmpezar2.gameObject.SetActive (false);

            } 

			if (hit.transform.gameObject.name == "Jugar") {
                
				btJugar.gameObject.SetActive (false);
				btJugar2.gameObject.SetActive (true);

				if (/* OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)||*/ Input.GetMouseButtonDown(0)) {
                    SceneManager.LoadScene("Game");
                }
            } else {

				btJugar.gameObject.SetActive (true);
				btJugar2.gameObject.SetActive (false);

            }

			if (hit.transform.gameObject.name == "Creditos") {
                
				btCreditos.gameObject.SetActive (false);
				btCreditos2.gameObject.SetActive (true);

				if (/* OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)||*/ Input.GetMouseButtonDown(0)) {
                    menuCanvas.gameObject.SetActive (false);
                    creditosCanvas.gameObject.gameObject.SetActive (true);
                }
            } else {

				btCreditos.gameObject.SetActive (true);
				btCreditos2.gameObject.SetActive (false);

            }
			if (hit.transform.gameObject.name == "Atras") {
                
				btBack.gameObject.SetActive (false);
				btBack2.gameObject.SetActive (true);

				if (/* OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)||*/ Input.GetMouseButtonDown(0)) {
                    menuCanvas.gameObject.SetActive (true);
                    creditosCanvas.gameObject.gameObject.SetActive (false);
                }
            } else {

				btBack.gameObject.SetActive (true);
				btBack2.gameObject.SetActive (false);

            }
	}
}
}
