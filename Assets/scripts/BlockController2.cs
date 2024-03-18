using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController2 : MonoBehaviour {
    [SerializeField]
    private GameObject[] blocks;

    private int tlBlocks;

    public static BlockController2 instance;
    // Use this for initialization
    private void Awake(){
        if (instance == null){
            instance = this;
        }
        else{
            if (instance != this){
                Destroy(this);
            }
        }
    }
    void Start(){
        this.CreateBlock();
    }
	
	// Update is called once per frame
	void Update(){
		
	}
    public int GetTlBlocks(){
        return tlBlocks;
    }

    public void DecTlBlocks(){
        tlBlocks--;
    }
    void CreateBlock(){
        float px = -96f;
        float py = 80f;
        tlBlocks = 0;
        // Instantiate(blocks[0], new Vector3(0, 10f, 0), Quaternion.identity);
        // tlBlocks++;
        for (int i = 0; i < 5; i++){
            px = -96f;
            for (int j = 0; j < 13; j++){
                Vector3 pos = new Vector3(px, py, 0);
                //criar o block na tela
                Instantiate(blocks[i], pos, Quaternion.identity);
                px = px + 16;
                tlBlocks++;
            }
            py = py - 8;
        }
    }
}