using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
  
	public bool canCounter { get; private set; }
	public int currentPosition { get; private set; }
	public int id { get; private set; }

	// Each player maintain own selected cards and card options
	private CardBase[] _selectedCardList;

	// Managers
	private MapManager _mapManager;

	// Player properties
	private int _health;
	private int _attackRange;

	void Start(){

	}
	public void Init(int playerId){
		id = playerId;
		_health = Constants.MAX_HEALTH;
		_attackRange = Constants.ATTACK_RANGE;
		_mapManager = MapManager.Instance;
		currentPosition = _mapManager.GetStartPosition(id);
    }  
	public void Reset(){
		canCounter = false;
	}
	// Try to move to the new position
	public void Move(int moveAmount){
		int newPosition = currentPosition + moveAmount;

		// Check limits
		if(newPosition < 0){
			newPosition = 0;
		}else if(newPosition > Config.MAP_LENGTH-1){
			newPosition = Config.MAP_LENGTH-1;
		}
		currentPosition = newPosition;
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
	public bool IsInAttackRange(int enemyPosition){
		return enemyPosition <= (currentPosition+_attackRange) && enemyPosition >= (currentPosition-_attackRange);
	}
	public void SetCounter(bool counter){
		canCounter = counter;
	}
}
