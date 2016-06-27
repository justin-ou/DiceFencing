using UnityEngine;
using System.Collections;

public class CardBase : MonoBehaviour {

	// Types of Card:
	// Attack: Deal damage to player if in range
	// Counter: Deal damage to player if attacked
	// Move: Move x-position
	// Heal: Recover health

	protected PlayerManager _playerManager;
	protected int _playerId;
	protected int _value;
	protected CardType _cardType;

	public virtual void Init(int playerId, int value){
		Init(playerId);
		_value = value;
	}
	public virtual void Init(int playerId){
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
}
