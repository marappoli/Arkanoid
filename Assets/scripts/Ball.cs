using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{
    [SerializeField]
    private float speed = 200f;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void StartBall(){
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.up * speed;
    }

    float HitFactor(Vector2 Ball, Vector2 player, float playerWidth){
        //-1 -0.5 0 0.5 1
        return(Ball.x - player.x) / playerWidth;

    }

    private void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.name == "Racket"){

            //descobrir o valor de x
            float x = HitFactor(
                transform.position,
                col.transform.position,
                col.collider.bounds.size.x); 

            //calcula a direção da bola
            Vector2 dir = new Vector2(x, 1).normalized;

            //velocidade da bola
            body.velocity = dir * speed;
        }

        if(col.gameObject.name == "GameOver"){
            GameController.instance.LoadEndGame(GameState.GameOver);
            // Destroy(gameObject);

        }

    }
}
