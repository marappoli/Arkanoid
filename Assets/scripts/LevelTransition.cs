using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public int currentLevel = 1;

    public float delay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextLevel", delay);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene(){
        
    }

    public void LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Level 2");
        
    }

}
