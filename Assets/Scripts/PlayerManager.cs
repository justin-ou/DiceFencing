using UnityEngine;
using System.Collections;

public class PlayerManager : Singleton<PlayerManager> {

	// Use this class to maintain a list of all players in the game
	// This class always has the reference to the current player object
	private Player _myPlayer;
	private Player _otherPlayer;
	private MapManager _mapManager;

	void Start(){

	}

	public void Init(){

	}
	public bool CanMovePosition(int position1, int position2){
		// player 1 position will be lesser than player 2 position since they can't pass one another
		// players use a linear map where they can only meet on the same tile at max
		return !(position1 > position2);
	}
	public int GetNewPlayerPosition(int moveAmount, bool isMyPlayer){
		if(isMyPlayer){
			return _myPlayer.MoveNewPosition(moveAmount);
		}
		return _otherPlayer.MoveNewPosition(moveAmount);
	}
	public int GetPlayerPosition(int moveAmount, bool isMyPlayer){
		if(isMyPlayer){
			return _myPlayer.GetCurrentPosition();
		}
		return _otherPlayer.GetCurrentPosition();
	}
	// Attack player 
	public void AttackPlayer(int damage){
		if(_otherPlayer != null){
			_otherPlayer.ModifyHealth(-damage);
		}
	}
	// Heal player 
	public void HealPlayer(int healAmount){
		if(_myPlayer != null){
			_myPlayer.ModifyHealth(healAmount);
		}
	}

}
