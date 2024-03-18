using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "Ball2")
        {
            if(this.gameObject.tag == "BlockYellow"){
                GameController2.instance.AddPoints(10);
            }
            if(this.gameObject.tag == "BlockRed"){
                GameController2.instance.AddPoints(10);
            }
            if(this.gameObject.tag == "BlockGreen"){
                GameController2.instance.AddPoints(10);
            }
            if(this.gameObject.tag == "BlockBlue"){
                GameController2.instance.AddPoints(10);
            }
            if(this.gameObject.tag == "BlockPink"){
                GameController2.instance.AddPoints(10);
            }
            
            BlockController2.instance.DecTlBlocks();
            Destroy(gameObject);
        }
    }
}