using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CyberSoldier : MonoBehaviour
{

    //enlistar los posibles estados de vida de cyberSoldier
    public enum State
    {
        VIVO, MURIENDO, DESAPARECIENDO
    }
    public State cyberSoldierState = State.VIVO;

    Transform playerSeguir;
    public float timeBetweenAttacks = 0.5f;
    GameObject jugador;
    public float attackRange;

    //referecia a la vida del jugador
    Player jugadorVida;

    //vida Jugador
    //public int vidaInicial =

    //audios reproducidos por cybersoldier
    public AudioClip spawnClip;
    public AudioClip hitClip;
    public AudioClip dieClip;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AudioSource audioSource;
    //cantidad de vida tomada por cybersoldier al jugador
    public int attackDamage;
   

    //vida de cada cyebrsoldier
    public int maxHealth;
    private int currHealth;
    //var de velocidad con la que desaparecera el robot
    public float sinkSpeed;

    float timer;
    bool playerInRange;

    // Use this for initialization
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador");
        jugadorVida = jugador.GetComponent<Player>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource.PlayOneShot(spawnClip);
        currHealth = maxHealth;
        playerSeguir = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == jugador)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == jugador)
        {
            playerInRange = false;
        }
    }*/

    // Update is called once per frame
    public void Attack()
    {
        timer = 0f;
       // print("atacando");
        animator.SetBool("Attack", true);
        audioSource.PlayOneShot(hitClip, 1.0f);
        //print("pongo audio");
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks)
        {
            timer = 0f;
            if (jugadorVida.health > 0)
            {
                jugadorVida.Hurt(attackDamage);
            }
        }
    }


    void Update()
    {
        /*
        timer += Time.deltaTime;
        if(timer >= timeBetweenAttacks)
        {
            Attack();
        }*/

        if (cyberSoldierState == State.VIVO)
        {
            //actualizar las coordenadas que seguira cyberSoldier para moverse
            //respecto al jugador
            navMeshAgent.SetDestination(playerSeguir.position);

            //calcular la distancia entre cyberSoldier y player
            Vector3 distanceVector = transform.position - playerSeguir.position;
            distanceVector.y = 0;
            float distance = distanceVector.magnitude;

            //revisar la distancia, activar o no la transition a attack
            if (distance <= attackRange)
            {
                animator.SetBool("Attack", true);
                audioSource.PlayOneShot(hitClip, 1.0f);

                timer += Time.deltaTime;
                if (timer >= timeBetweenAttacks)
                {
                    timer = 0f;
                    if (jugadorVida.health > 0)
                    {
                        jugadorVida.Hurt(attackDamage);
                    }/*
                    else
                    {
                        animator.SetTrigger("PlayerDead");
                    }*/
                }

                //Attack();

                //print("atacando222");
            }
        }
        //distancia cyberSoldier bajar mientras desaparece
        else if (cyberSoldierState == State.DESAPARECIENDO)
        {
            float sinkDistance = sinkSpeed * Time.deltaTime;
            transform.Translate(new Vector3(0, -sinkDistance, 0));
        }
        
    }

    //revisar por que no lee la funcion attack _????



    public void Hurt(int damage)
    {
        if (cyberSoldierState == State.VIVO)
        {
            animator.SetTrigger("Hurt");
            currHealth -= damage;
            if (currHealth <= 0)
                Die();
        }
    }

    void Die()
    {
        //establecer el estado del robot
        cyberSoldierState = State.MURIENDO;
        //activar el sonido de agonia
        audioSource.PlayOneShot(dieClip);
        //parar el seguimiento a player
        navMeshAgent.isStopped = true;
        //activar la animacion ,Dead, pertinente
        animator.SetTrigger("Dead");

        //test
        //print("robot Exterminado");
    }

    //permanecer en el suelo hasta desaparecer, despues de morir
    public void StartSinking()
    {
        //establecer el estado del robot
        cyberSoldierState = State.DESAPARECIENDO;
        //desabilitar el componente de navegacion
        //para mantener al robot estatico
        navMeshAgent.enabled = false;
        //establecer cyberSoldier para ser exterminado.
        //desaparacer despues de un tiempo determinado.
        Destroy(gameObject, 5);
    }

}
