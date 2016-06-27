using UnityEngine;
using System.Collections;

public class MoveCard : CardBase {

	public override void Init(int playerId, int value){
		base.Init(playerId, value);
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
