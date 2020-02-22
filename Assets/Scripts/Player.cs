using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    //vida con la que el jugador inicia. reocmendacion 100 sino cambiar datos en slider vida
    public int maxHealth;
    //vida del jugador actualizada
    public int health;
    // referencia al UI health bar
    public Slider barraVida; 
    //referencia a la imagen a monstrar mientras eres lastimado
    public Image danoImagen;
    //velocidad danoImagen parapdeara
    public float flashSpeed;
    //color de la imagen a parpadear
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    public Animator anim;
    public Animator animE;
    int contador = 0;
    private AudioSource audioSource;
    public AudioClip endGame;
    
    bool damaged;

    public enum State {
    VIVO, MUERTO
    }

    public State playerState = State.VIVO;

    
    bool loadingStarted = false;
    float secondsLeft = 0;



    // Use this for initialization
 public void Start () {
      
        audioSource = GetComponent<AudioSource>();
        //setear la vida del jugador al inicio de la partida
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

        //si el jugador ha sido lastimado...
        if (damaged)
        {
            //... cambiar el color al flashColor
            danoImagen.color = flashColor;
        }
        //sino... 
        else
        {
            //... limpiar y volver al canvas sin color
            danoImagen.color = Color.Lerp(danoImagen.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //resetear la variable de lastimado
        damaged = false;


    }

    public void Hurt(int damageOnPlayer) {
        if(playerState == State.VIVO)
        {
            //setear lastimado a verdadero para que la pantalla muestre flashColor
            damaged = true;
            //reducir la vida segun el dano inflingido por cybersoldier
            health -= damageOnPlayer;
            //actualizar healthbar segun la vida actual 
            barraVida.value = health;
            
            //si el jugador ha perdido toda la vida y esta muerto...
            if (health <= 0)
            {
                //... debe estar muerto

                Muerto();
               
                
                //SceneManager.LoadScene(2);
                animE.SetBool("Idle", true);
                print("muerto por siempre");
            }
        }


        

    }

   public void Muerto()
    {

        anim.SetTrigger("FadeOut");

        StartCoroutine(DelayLoadLevel());

        //establecer que el estado del jugador es MUERTO
        playerState = State.MUERTO;
        //sonido final del juego
     
        audioSource.PlayOneShot(endGame);
        
        //cargar escena(segunda Escena) final del juego Experiencia
        //SceneManager.LoadScene(2);

    }

    IEnumerator DelayLoadLevel()
    {
  
            yield return new WaitForSeconds(5);
            print("GAME OVER");
            SceneManager.LoadSceneAsync(6);
    }

    private void OnGUI()
    {
        if (health <= 0)
        {
            GUIStyle guiStyle = new GUIStyle();
            guiStyle.fontSize = 40;
           // guiStyle.alignment = TextAnchor.MiddleCenter;
            GUI.Label(new Rect(Screen.width/2,200, Screen.width / 2, 200), "GAME OVER", guiStyle);
        }
    }

}
