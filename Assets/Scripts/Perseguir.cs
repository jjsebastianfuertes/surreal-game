using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : MonoBehaviour {

    Transform player;
    public NavMeshAgent nav;
    Player vidaJugador;
    VidaEnemigo vidaEnemigo;


    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        vidaJugador = player.GetComponent<Player>();
        vidaEnemigo = GetComponent<VidaEnemigo>();

        nav = GetComponent<NavMeshAgent>();
    }
    // Use this for initialization
    void Start() {

        //nav.SetDestination (player.position);
    }

    // Update is called once per frame
    void Update() {
        //nav.SetDestination (player.position);

        if (vidaEnemigo.vidaActual > 0 && vidaJugador.health > 0) {

            nav.SetDestination(player.position);


        } else {
            nav.enabled = false;
        }

    }
}
