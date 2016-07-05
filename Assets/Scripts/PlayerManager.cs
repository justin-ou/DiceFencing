using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : Singleton<PlayerManager> {

	// Use this class to maintain a list of all players in the game
	private List<Player> _playerList;

	// Instantiate player prefab
	private GameObject _playerPrefab;
	private Transform _playerParentTransform;

	void Awake(){
		_playerList = new List<Player>();
		_playerParentTransform = GameObject.Find("PlayerList").transform;
		_playerPrefab = Resources.Load("Prefabs/PlayerObject") as GameObject;
	}
	// Add a new player when he joins the game
	public Player AddPlayer(){
		if(_playerList.Count < Constants.MAX_PLAYERS){
			Player newPlayer = Utilities.InstantiateParent(_playerPrefab, _playerParentTransform).GetComponent<Player>();
			newPlayer.Init(_playerList.Count);
			// Add to list of current players
			_playerList.Add(newPlayer);
			// Update UI of player in the list
			return newPlayer;
		}
		return null;
	}
	// Get the player class to do something
	public Player GetPlayer(int id){
		if(Utilities.IsInArrayRange(id, _playerList.Count)){
			return _playerList[id];
		}
		return null;
	}
	public int GetPlayerLength(){
		return _playerList.Count;
	}
	// Attack other players
	public void AttackPlayer(int attackerId, int attackValue){
		Player attacker = GetPlayer(attackerId);
		foreach(Player player in _playerList){
			if(player != attacker && attacker.IsInAttackRange(player.currentPosition)){
				if(player.canCounter){
					// Counter attack
					attacker.ModifyHealth(attackValue);
				}else{
					player.ModifyHealth(attackValue);
				}
			}
		}
	}
}
