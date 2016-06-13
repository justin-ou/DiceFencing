using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardManager : Singleton<CardManager> {

	// Maintain selected cards and card options
	private CardBase[] _selectedCardList;
	private CardBase[] _opponentCardList;

	void Start(){

	}

	public void Init(){
		_selectedCardList = new CardBase[Config.CARD_LENGTH];
		_opponentCardList = new CardBase[Config.CARD_LENGTH];
	}
	public void ResetCardList(){
		for(int i=0; i<_selectedCardList.Length; i++){
			_selectedCardList[i] = null;
			_opponentCardList[i] = null;
		}
	}
	public void SetCard(int index, CardBase card){
		if(index > 0 && index < _selectedCardList.Length && card != null){
			_selectedCardList[index] = card;
		}
		// Error in setting card
		Debug.Log("Set Card Error!");
	}

	// Players select 5 cards they wish to play (CardManager)
	// Players confirm selection (CardManager)
	// Lock player's input (GameManager/PlayerManager/Conflict?)
	// Take Card 1 from all players and execute action (Send to other player)
	// Host: Determine which action executes first from all players (Host performs action)
	// Resolve action, eg Attack and Move, move player first to update position, attack to see if in range (Host resolve action and update player)
	// Take Cards 2-5
	// Unlock player's input
	// Repeat
}
