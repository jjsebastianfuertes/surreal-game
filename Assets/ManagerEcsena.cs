using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerEcsena : MonoBehaviour {

    public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeOut()
    {

        anim.SetTrigger("FadeOut");

    }
    public void escenaMenu()
    {

        SceneManager.LoadSceneAsync("Final");

    }
}
