using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket2 : MonoBehaviour {
    [SerializeField]
    private float speed = 150f;
    private Rigidbody2D body;

    // Use this for initialization
    void Start (){
        body = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update (){
        
    }

    private void FixedUpdate(){
        if(GameController2.instance.gameState == GameState2.Play){
            float h = Input.GetAxis("Horizontal");
            body.velocity = Vector2.right * h * speed;
        }
        
    }
}
