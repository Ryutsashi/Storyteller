using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierPackage {
	string stat;
	float value;

	public string Stat { get { return stat; } }

	public float Value { get { return value; } }

	public ModifierPackage ( string stat, float value ) {
		this.stat = stat;
		this.value = value;
	}
}
