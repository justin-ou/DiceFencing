using UnityEngine;
using System.Collections;

public class HealCard : CardBase {

	private const int HEAL_VALUE = 4;

	public HealCard(int playerId, int value) : base(playerId, value){
		_priority = (int) CardType.HEAL;
		_cardType = CardType.HEAL;
	}
	public HealCard(int playerId) : base(playerId){
		_value = HEAL_VALUE;
		_priority = (int) CardType.HEAL;
		_cardType = CardType.HEAL;
	}
	public override void Execute(){
		// Uses PlayerManager find self
		// Heals own self according to value
		if(_playerManager.GetPlayer(_playerId) != null){
			_playerManager.GetPlayer(_playerId).ModifyHealth(_value);
		}
	}
}
