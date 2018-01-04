using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public CharacterStats stats;
	public CharacterEquipment equipment;

	private void Awake ( ) {
		stats = new CharacterStats ( );
		equipment = new CharacterEquipment ( );
	}

	// Subscribe to events on enable and unsubscribe on disable
	void OnEnable ( ) {
		//Turn.OnClicked += Teleport;
	}


	void OnDisable ( ) {
		//EventManager.OnClicked -= Teleport;
	}

	// implement in a class that deals with passive turns
	public void UpdateCharacter () {
		// calculate passive modifiers and apply to stats
	}
}
