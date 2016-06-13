using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {
    	
    private EventManager _eventManager;
    private Config _config;	
    private bool _gameStarted;
    public Player[] players { get; private set; }
    public bool paused { get; private set; }

    void Awake(){

    }

	// Use this for initialization
    void Start(){

	}


    public void StartGame(){
        
    }

    public void ResetGame() {

    }

    public void GameOver(int loser){
		
    }

    public void Restart(){
        
    }

    public void PauseGame(){
       
    }

    public void EndGame(){
        
    }

	// Update is called once per frame
	void Update () {

	}
}
