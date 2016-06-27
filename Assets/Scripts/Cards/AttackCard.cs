using UnityEngine;
using System.Collections;

public class AttackCard : CardBase {

	public override void Init(int playerId, int value){
		base.Init(playerId, value);
		_cardType = CardType.NORMAL_ATTACK;
	}
 	public override void Execute(){
		// Uses PlayerManager to attack area infront of current player
		// Attacks all players if possible
		// Deal damage according to value
		_playerManager.AttackPlayer(_playerId, _value);
	}
}
