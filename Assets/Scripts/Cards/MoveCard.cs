using UnityEngine;
using System.Collections;

public class MoveCard : CardBase {

	public MoveCard(int playerId, int value) : base(playerId, value){
		_priority = (int) CardType.MOVE;
		_cardType = CardType.MOVE;
	}
	public override void Execute(){
		// Uses PlayerManager to update Player's position on map
		// Move according to value amount 
		// +1 move forward, -1 move backward
		if(_playerManager.GetPlayer(_playerId) != null){
			_playerManager.GetPlayer(_playerId).Move(_value);
		}
	}
}
