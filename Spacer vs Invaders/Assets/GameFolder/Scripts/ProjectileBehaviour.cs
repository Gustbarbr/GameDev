using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4.5f;

    private ScoreManager scoreManager;

    void Start(){
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject); // Destroi o inimigo
            Destroy(gameObject); // Destroi a bala ao colidir com o inimigo
            scoreManager.ScorePointos();
        }
        if (collider.CompareTag("TheWall"))
        {
            Destroy(gameObject);
        }
    }
}
