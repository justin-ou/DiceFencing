using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CardManager : Singleton<CardManager> {

	// Maintain selected cards and card options
	private CardBase[] _selectedCardList;
	private CardBase[] _opponentCardList;
	private List<CardBase[]> _cardList;
	private PlayerManager _playerManager;

	void Start(){

	}

	public void Init(){
		_selectedCardList = new CardBase[Config.CARD_LENGTH];
		_opponentCardList = new CardBase[Config.CARD_LENGTH];
		_playerManager = PlayerManager.Instance;
		_cardList = new List<CardBase[]>();
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
	// Add player's card to general card list
	// Compare priority between arrays to determine order in general list
	private void GenerateTurnCardList(){
		// 5 selected cards for each player
		// Loop through selected cards for each player and sort 
		// Add to list
		int playerNum = _playerManager.GetPlayerLength();
		for(int i=0; i<Constants.CARD_LIST_LENGTH; i++){
			CardBase[] selectedCardList = new CardBase[playerNum];
			for(int j=0; j<playerNum; j++){
				selectedCardList[j] = _playerManager.GetPlayer(j).GetSelectedCard(i);
			}
			Array.Sort(selectedCardList);
			_cardList.Add(selectedCardList);
		}
	}
	// Execute cards after generating it based on the selected cards from each player
	public void ExecuteCardList(){
		GenerateTurnCardList();
		for(int i=0; i<_cardList.Count; i++){
			for(int j=0; j<_cardList[i].Length; j++){
				_cardList[i][j].Execute();
			}
		}
	}
}
