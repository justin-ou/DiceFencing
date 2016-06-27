using UnityEngine;
using System.Collections;

public class MapManager : Singleton<MapManager> {

	// Use this class to control where players can move to
	// Should consist a list of players to track positions
	// Linear Map

	// Positions according to map length
	private int[] START_POSITION = { 3, 12 };

	public int GetStartPosition(int playerId){
		if(Utilities.IsInArrayRange(playerId, START_POSITION.Length)){
			return START_POSITION[playerId];
		}
		return -1;
	}
	// Get Vector position based on index on map

}
