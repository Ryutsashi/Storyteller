using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateMachine {

	[SerializeField]
	List<State> availableStates;

	[SerializeField]
	State currentState;

	public void AddState (string name, string[] links) {
		foreach ( State s in availableStates ) {
			if ( s.Name == name ) {
				Debug.Log ( "Can't add a new state. A state with the name \"" + name + "\" already exists." );
				return;
			}
		}
		State newState = new State ( name );
		for (int i = 0; i < links.Length; i++) {
			newState.AddLink ( links [ i ] );
		}
		availableStates.Add ( newState );
	}

	public void RemoveState (string name) {
		State temp = GetState ( name );
		if ( temp == null ) {
			Debug.Log ( "Can't remove state \"" + name + "\"." );
			return;
		}
		availableStates.Remove ( temp );
	}

	public void AdvanceState (int option) {
		if (currentState.Links.Count > option) {
			State nextState = GetState ( currentState.Links [ option ] );
			if (nextState ==  null) {
				Debug.Log ( "Can't advance state \"" + currentState.Name + "\" to \"" + currentState.Links [ option ] + "\"." );
				return;
			}
			currentState = nextState;
		}
	}

	public State GetState (string name) {
		foreach (State s in availableStates) {
			if (s.Name == name) {
				return s;
			}
		}
		Debug.Log ( "State \"" + name + "\" not found!" );
		return null;
	}

	public List<State> GetAllStates ( ) {

		return availableStates;
	}

	public string GetCurrentState () {
		return currentState.Name;
	}
}
