using UnityEngine;
using System.Collections;

public class CounterCard : CardBase {

	public CounterCard(int playerId) : base(playerId){
		_priority = (int) CardType.COUNTER;
		_cardType = CardType.COUNTER;
	}
	public override void Execute(){
		// Set Player's counter flag to true
		// Reflect's damage if damage is taken this turn
		// Resets Player's counter flag
		if(_playerManager.GetPlayer(_playerId) != null){
			_playerManager.GetPlayer(_playerId).SetCounter(true);
		}
	}
}
