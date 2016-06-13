using UnityEngine;
using System.Collections;

public class AttackCard : CardBase {

	private int _damage;

	public AttackCard(int damage) : base(){
		_damage = damage;
	}
 	public override void Execute(){
		// Reduce opponent player health by _damage amount
	}
}
