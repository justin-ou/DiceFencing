using UnityEngine;
using System.Collections;
using System;

public class CardBase : IComparable<CardBase>{

	// Types of Card:
	// Attack: Deal damage to player if in range
	// Counter: Deal damage to player if attacked
	// Move: Move x-position
	// Heal: Recover health

	protected PlayerManager _playerManager;
	protected int _playerId;
	protected int _value;
	protected CardType _cardType;
	protected int _priority; // Each card has its own priority to be used for sorting

	public CardBase(int playerId, int value) : this(playerId){
		_value = value;
	}
	public CardBase(int playerId){
		_playerId = playerId;
		_playerManager = PlayerManager.Instance;
	}
	// Execute action after CardManager sorts card priority
	// Uses PlayerManager to check against other players
	public virtual void Execute(){
		// Perform this card action
	}
	public virtual void Serialize(){

	}
	public virtual void DeSerialize(){

	}
	public int CompareTo(CardBase other){
		return _priority.CompareTo(other._priority);
	}
}
