using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State {

	[SerializeField]
	string name;
	public string Name { get { return name; } }

	[SerializeField]
	List<string> links;
	public List<string> Links { get { return links; } }

	public State (string name) {
		this.name = name;
		links = new List<string> ( );
	}

	public virtual void AddLink (string name) {
		links.Add ( name );
	}

	public virtual void RemoveLink (string name) {
		links.Remove ( name );
	}

	public void Rename ( string newName ) {
		name = newName;
	}

	public virtual void ModifyLink ( int index, string newName ) {
		links [ index ] = newName;
	}
}
