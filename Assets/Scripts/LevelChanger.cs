using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
        FadeToLevel(1);
	}

    public void FadeToLevel(int levelIndex)
    {

        anim.SetTrigger("FadeOut");

    }

    public void OnFadeComplete()
    {
      //  SceneManager.LoadScene("");
    }
}
