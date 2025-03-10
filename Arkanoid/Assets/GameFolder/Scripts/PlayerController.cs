using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public KeyCode moveLeft = KeyCode.A;      //UP
    public KeyCode moveRight = KeyCode.D; 
    public float speed = 10.0f;            
    private float boundX = 9.3f;           
    private Rigidbody2D rb2d;
    public int playerHP = 3;

    public GameObject gameManager;

    void Start()
    {
        Scene cenaAtual = SceneManager.GetActiveScene();
        string nomeCena = cenaAtual.name;

        // Garantir que só haja um player na cena
        if (FindObjectsOfType<PlayerController>().Length > 1)
        {
            Destroy(gameObject);  // Se já existe uma instância do jogador, destrua este
        }
        if(nomeCena == "CenaGanhar" || nomeCena == "CenaMorte")
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);  // Faz o objeto não ser destruído
        }

        rb2d = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        GameManager gm = gameManager.GetComponent<GameManager>();
        gm.Fase2();
        gm.Vitoria();

        var vel = rb2d.velocity;                
        if (Input.GetKey(moveLeft)) {             
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight)) {      
            vel.x = speed;                    
        }
        else {
            vel.x = 0;                          
        }
        rb2d.velocity = vel;                    

        var pos = transform.position;           
        if (pos.x > boundX) {                  
            pos.x = boundX;                     
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    
        }
        transform.position = pos; 
        
        if(playerHP <= 0)
        {
            SceneManager.LoadScene("CenaMorte");
        }
    }

    public void ResetPlayer()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(0f, -4f);
    }
}
