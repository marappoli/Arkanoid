using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum GameState { Stop, Play, Win, GameOver, Pause };

public class GameController : MonoBehaviour{

    public static GameController instance;

    [SerializeField]
    TextMeshProUGUI txtScore;

    [SerializeField]
    TextMeshProUGUI txtMsg;

    [SerializeField]
    private GameObject Ball;

    [SerializeField]
    private GameObject Player;

    private float score;
    public GameState gameState;
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
        gameState = GameState.Stop;
        //StartGame();
        
    }

    // Update is called once per frame
    void Update(){
        txtScore.text = "Score: " +this.score;
        if(Input.GetKeyUp(KeyCode.Space) && gameState == GameState.Stop){
            StartGame();
        }

        if(BlockController.instance.GetTlBlocks() <= 0 && gameState == GameState.Play){
            LoadEndGame(GameState.Win);
        }

        if(Input.GetKeyDown(KeyCode.Space) && gameState == GameState.Play 
        || Input.GetKeyDown(KeyCode.Space) && gameState == GameState.Pause){
            PauseGame();
        }
    }

    public void AddPoints(float valor){
        this.score += valor;
    }

    public void StartGame(){
        gameState = GameState.Play;
        score = 0;
        Ball.GetComponent<Ball>().StartBall();
        txtMsg.gameObject.SetActive(false);
    }

    public void LoadEndGame(GameState valor){
        gameState = valor;
        txtMsg.gameObject.SetActive(true);
        if(gameState == GameState.GameOver){
            txtMsg.text = "Game Over";
        }
        else{
            txtMsg.text = "Win!";
        }
        if(Ball != null){
            Ball.SetActive(false);
        }
        Invoke("RestartGame", 5);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame(){
        if(Time.timeScale == 0){
            gameState = GameState.Play;
            Time.timeScale = 1;
            txtMsg.gameObject.SetActive(false);
        }
        else{
            gameState = GameState.Pause;
            Time.timeScale = 0;
            txtMsg.gameObject.SetActive(true);
            txtMsg.text = "Pause \n Press space to continue";
        }
        
    }
}
