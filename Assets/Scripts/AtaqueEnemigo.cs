using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour {

    public float tiempoEntreAtaques = 0.5f;
    public int DanoAtaque = 10;
    VidaEnemigo vidaEnemigo;
    GameObject player;
    Player vidaPlayer;

    private AudioSource audioSource;

    bool playerEnRango;
    float timer;

    public Animator Anim;

    //audios reproducidos por cybersoldier
    public AudioClip spawnClip;
    public AudioClip hitClip;
    public AudioClip dieClip;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        vidaPlayer = player.GetComponent<Player>();
        vidaEnemigo = GetComponent<VidaEnemigo>();
        //Anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start() {
        audioSource.PlayOneShot(spawnClip);
    }

    void OnTriggerEnter(Collider other) {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject == player) {
            Debug.Log("Player encontrado");
            playerEnRango = true;
            Anim.SetBool("Attack", true);
        }

    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject == player) {
            playerEnRango = false;
        }
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer >= tiempoEntreAtaques && playerEnRango && vidaEnemigo.vidaActual > 0) {
            Atacar();
        }

        /*
        if(vidaPlayer.vidaActual <= 10){
            SceneManager.LoadScene ("Final");
        }
            */
    }


    void Atacar() {

        timer = 0;
        audioSource.PlayOneShot(hitClip, 1.0f);
        if (vidaPlayer.health > 0) {
            vidaPlayer.Hurt(DanoAtaque);
        }
    }
}
