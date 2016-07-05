using UnityEngine;
using System.Collections;

public class AttackCard : CardBase {

	private const int MIN_ATTACK = 1;
	private const int MAX_ATTACK = 7;

	public AttackCard(int playerId, int value) : base(playerId, value){
		_priority = (int) CardType.NORMAL_ATTACK;
		_cardType = CardType.NORMAL_ATTACK;
	}
	public AttackCard(int playerId) : base(playerId){
		_value = Random.Range(MIN_ATTACK, MAX_ATTACK);
		_priority = (int) CardType.NORMAL_ATTACK;
		_cardType = CardType.NORMAL_ATTACK;
	}
 	public override void Execute(){
		// Uses PlayerManager to attack area infront of current player
		// Attacks all players if possible
		// Deal damage according to value
		_playerManager.AttackPlayer(_playerId, _value);
	}
}
