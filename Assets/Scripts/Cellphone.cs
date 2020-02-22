using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellphone : MonoBehaviour {

   public AudioSource audioSource;
   private GameObject smartphone;

    private bool holdingPhone = false;
    bool playerInRange;

    // Use this for initialization
   void Start () {
        audioSource = GetComponent<AudioSource>();
        smartphone = GameObject.FindGameObjectWithTag("smartphone");

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == smartphone)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == smartphone)
        {
            playerInRange = false;
        }
    }


}
    