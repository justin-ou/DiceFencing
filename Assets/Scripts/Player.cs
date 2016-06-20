using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
  
	//private 
    private GameManager _gameManager;   
    private EventManager _eventManager;

	// Each player maintain own selected cards and card options
	private CardBase[] _selectedCardList;

	// Id 1 face right, Id 2 face left
	private int _id;
	private int _health;
	private int _currentPosition;

    public Player(){

    }

	// Use this for initialization
	void Start () {

	}

    public void Init(int id) {
		_id = id;
		_health = Constants.MAX_HEALTH;
    }
	public void MoveToPosition(int newPosition){
		_currentPosition = newPosition;
	}
	// Try to move to the new position
	// See if players are trying to move past one another 
	public int MoveNewPosition(int moveAmount){
		int newPosition = _currentPosition + moveAmount;

		// Check limits
		if(newPosition < 0){
			newPosition = 0;
		}else if(newPosition > Config.MAP_LENGTH-1){
			newPosition = Config.MAP_LENGTH-1;
		}
		return newPosition;
	}
	public void ModifyHealth(int health){
		int tempHealth = _health + health;
		if(tempHealth < 0){
			// Death condition
			tempHealth = 0;
		}else if(tempHealth > Constants.MAX_HEALTH){
			// Heal back to full
			tempHealth = Constants.MAX_HEALTH;
		}
		_health = tempHealth;
	}

	public int GetCurrentPosition(){
		return _currentPosition;
	}
}
