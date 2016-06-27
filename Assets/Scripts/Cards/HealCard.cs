using UnityEngine;
using System.Collections;

public class HealCard : CardBase {

	public override void Init(int playerId, int value){
		base.Init(playerId, value);
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
