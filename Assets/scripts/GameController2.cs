using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum GameState2 { Stop, Play, Win, GameOver, Pause };

public class GameController2 : MonoBehaviour{

    public static GameController2 instance;

    [SerializeField]
    TextMeshProUGUI txtScore;

    [SerializeField]
    TextMeshProUGUI txtMsg;

    [SerializeField]
    private GameObject Ball2;

    [SerializeField]
    private GameObject Player;

    private float score;
    public GameState2 gameState;

    public int currentLevel = 1;

    public float delay = 2f;

    private void Awake(){

        if(instance == null){
            instance = this;
        }
        else{
            if(instance != this){
                Destroy(this);
            }
        }
    }
    // Start is called before the first frame update
    void Start(){
        gameState = GameState2.Stop;
        //StartGame();
        
    }

    // Update is called once per frame
    void Update(){
        txtScore.text = "Score: " +this.score;
        if(Input.GetKeyUp(KeyCode.Space) && gameState == GameState2.Stop){
            StartGame();
        }

        if(BlockController2.instance.GetTlBlocks() <= 0 && gameState == GameState2.Play){
            LoadEndGame(GameState2.Win);
        }

        if(Input.GetKeyDown(KeyCode.Space) && gameState == GameState2.Play 
        || Input.GetKeyDown(KeyCode.Space) && gameState == GameState2.Pause){
            PauseGame();
        }
    }

    public void AddPoints(float valor){
        this.score += valor;
    }

    public void StartGame(){
        gameState = GameState2.Play;
        score = 0;
        Ball2.GetComponent<Ball2>().StartBall();
        txtMsg.gameObject.SetActive(false);

        //SceneManager.LoadScene("Level " + currentLevel);
    }

    public void LoadEndGame(GameState2 valor){
        gameState = valor;
        txtMsg.gameObject.SetActive(true);
        if(gameState == GameState2.GameOver){
            txtMsg.text = "Game Over";
        }
        else{
            txtMsg.text = " ";
            LoadNextLevel();
        }
        if(Ball2 != null){
            Ball2.SetActive(false);
        }
        Invoke("RestartGame", 5);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame(){
        if(Time.timeScale == 0){
            gameState = GameState2.Play;
            Time.timeScale = 1;
            txtMsg.gameObject.SetActive(false);
        }
        else{
            gameState = GameState2.Pause;
            Time.timeScale = 0;
            txtMsg.gameObject.SetActive(true);
            txtMsg.text = "Pause \n Press space to continue";
        }
        
    }

    public void LoadNextScene(){
        Invoke("LoadNextLevel", delay);
    }

    public void LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("WinScene");
    }

    
}
