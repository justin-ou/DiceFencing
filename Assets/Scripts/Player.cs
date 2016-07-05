using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
  
	public bool canCounter { get; private set; }
	public int currentPosition { get; private set; }
	public int id { get; private set; }

	// Each player maintain own selected cards and card options
	private CardBase[] _selectedCardList;
	private CardBase[] _generatedCardList;

	// Managers
	private MapManager _mapManager;

	// Player properties
	private int _health;
	private int _attackRange;

	private const int COUNTER_CHANCE = 50;
	private const int HEALING_CHANCE = 50;

	void Start(){

	}
	public void Init(int playerId){
		id = playerId;
		currentPosition = _mapManager.GetStartPosition(id);
		canCounter = false;
		_health = Constants.MAX_HEALTH;
		_attackRange = Constants.ATTACK_RANGE;
		_mapManager = MapManager.Instance;
		_selectedCardList = new CardBase[Constants.CARD_LIST_LENGTH];
		_generatedCardList = new CardBase[Constants.CARD_LIST_LENGTH];
    }  
	public void ResetTurn(){
		canCounter = false;
		EmptyArray(ref _selectedCardList);
		GenerateCard();
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
	public bool SetSelectedCard(int selectedIndex, int cardIndex){
		if(!Utilities.IsInArrayRange(selectedIndex, Constants.CARD_LIST_LENGTH)) return false;
		if(!Utilities.IsInArrayRange(selectedIndex, Constants.CARD_LIST_LENGTH)) return false;
		_selectedCardList[selectedIndex] =  _generatedCardList[cardIndex];
		return true;
	}
	public CardBase GetSelectedCard(int selectedIndex){
		if(Utilities.IsInArrayRange(selectedIndex, Constants.CARD_LIST_LENGTH)){
			return _selectedCardList[selectedIndex];
		}
		return null;
	}
	private void GenerateCard() {
		// Empty list
		// Add 2 random attack cards to list
		// Add 1/2 counter card to list
		// Add healing or no action card to list
		_generatedCardList[0] = new AttackCard(id);
		_generatedCardList[1] = new AttackCard(id);
		_generatedCardList[2] = new CounterCard(id);
		if(Utilities.IsLessThanPercentage(COUNTER_CHANCE)){
			_generatedCardList[3] = new CounterCard(id);
		}else{
			_generatedCardList[3] = new NoActionCard(id);
		}
		if(Utilities.IsLessThanPercentage(HEALING_CHANCE)){
			_generatedCardList[4] = new HealCard(id);
		}else{
			_generatedCardList[4] = new NoActionCard(id);
		}			
	}
	private void EmptyArray(ref CardBase[] cardList){
		for(int i=0; i<cardList.Length; i++){
			cardList[i] = null;
		}
	}
}
