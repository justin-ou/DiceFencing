using UnityEngine;
using System.Collections;

public class NoActionCard : CardBase {

	public NoActionCard(int playerId) : base(playerId){
		_cardType = CardType.NO_ACTION;
	}
}
