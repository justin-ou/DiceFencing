using UnityEngine;
using System.Collections;

public class CounterCard : CardBase {

	private int _damage;

	public CounterCard(int damage) : base(){
		_damage = damage;
	}
	public override void Execute(){
		// Reduce opponent player health by _damage amount if correct card type
	}
}
