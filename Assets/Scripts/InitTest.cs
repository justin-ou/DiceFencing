using UnityEngine;
using System.Collections;

public class InitTest : MonoBehaviour {

	private PlayerManager _playerManager;

	// Use this for initialization
	void Awake () {
		_playerManager = PlayerManager.Instance;
	}
	void Start () {
		_playerManager.AddPlayer();
		_playerManager.AddPlayer();
	}	
	// Update is called once per frame
	void Update () {
	
	}
}
