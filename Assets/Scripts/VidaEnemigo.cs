using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VidaEnemigo : MonoBehaviour {

    public int vidaInicial = 100;
    public int vidaActual;
    public float desaparecer = 2.5f;
    CapsuleCollider capsuleCollider;
    SphereCollider sphereCollider;
    //static Animator anim;
    private AudioSource audioSource;
    public bool muerto;
    bool desapareciendo;
    public AudioClip dieClip;
    Animator Anim;

    void Awake() {
        capsuleCollider = GetComponent<CapsuleCollider>();

        sphereCollider = GetComponent<SphereCollider>();


        vidaActual = vidaInicial;

        Anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start() {



    }

    // Update is called once per frame
    void Update() {

        //Debug.Log(vidaActual);

        if (desapareciendo) {
            transform.Translate(-Vector3.up * desaparecer * Time.deltaTime);
        }

    }

    public void Lastimarse(int cantidad) {

        if (muerto)
            return;
        Anim.SetTrigger("Hurt");
        vidaActual -= cantidad;

        if (vidaActual <= 0) {
            sphereCollider.isTrigger = true;
            Muerte();
        }

    }

    void Muerte() {
        Debug.Log("murio");
        muerto = true;
        audioSource.PlayOneShot(dieClip);
        capsuleCollider.isTrigger = true;

        //gameObject.SetActive (false);

        Anim.SetBool( "Muerto", true);
        audioSource.PlayOneShot(dieClip);
        //animacioo4n de muerte
        //Sonidos
    }



    public void empezarDesaparecer() {
        
         GetComponent<NavMeshAgent>().enabled = false;
         GetComponent<Rigidbody>().isKinematic = true;
         desapareciendo = true;
       

        Destroy(gameObject, 0f);
    }
}
