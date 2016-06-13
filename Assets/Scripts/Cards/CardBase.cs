using UnityEngine;
using System.Collections;

public class CardBase : MonoBehaviour {

	// Types of Card:
	// Attack: Deal damage to player if in range
	// Counter: Deal damage to player if attacked
	// Move: Move x-position
	// Heal: Recover health

	public void Attack(int damage){
		// Attack area in front of the player
		// Send to ConflictManager that accepts Card command from all players
		// ConflictManager receives a Card command and their player Id
		// Resolves highest damage number first
		// Deals damage if a player is within range
		// After all players has been processed, move to next command

	}
	public virtual void Execute(){
		// Perform this card action
	}
	public virtual void Serialize(){

	}
	public virtual void DeSerialize(){

	}
}
