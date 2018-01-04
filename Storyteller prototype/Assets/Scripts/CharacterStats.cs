using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public List<Stat> stats = new List<Stat> ( );

	private void Start ( ) {

		// physical fitness and asociated dynamic variables
		stats.Add( new Stat (
				"Health",
				"Current health",
				100f ));
		stats.Add ( new Stat (
			"Maximum Health",
			"Health when full",
			100f ));
		stats.Add ( new Stat (
			"Food",
			"Fullnes of the stomach",
			100f ));
		stats.Add ( new Stat (
			"Maximum Food",
			"Food when full",
			100f ));
		stats.Add ( new Stat (
			"Water",
			"Current thirstiness",
			100f ));
		stats.Add ( new Stat (
			"Maximum Water",
			"Maximum water when not thirsty",
			100f ));
		stats.Add ( new Stat (
			"Endurance",
			"Current exertion level",
			100f ));
		stats.Add ( new Stat (
			"Maximum Endurance",
			"Maximum extertion level when rested",
			100f ));
		stats.Add ( new Stat (
			"Age",
			"Age in years",
			20f ));
		stats.Add ( new Stat (
			"Max Age",
			"Estimated lifespan",
			50f ));

		// base stats
		stats.Add ( new Stat (
			"Strenght",
			"Physical strenght",
			0f ));
		stats.Add ( new Stat (
			"Speed",
			"General movement speed",
			0f ));
		stats.Add ( new Stat (
			"Reflex",
			"Reaction time",
			0f ));
		stats.Add ( new Stat (
			"Intelligence",
			"Problem-solving and mental agility",
			0f ));
		stats.Add ( new Stat (
			"Willpower",
			"Self-control",
			0f ));
		stats.Add ( new Stat (
			"Speechcraft",
			"General verbal skills",
			0f ));
		stats.Add ( new Stat (
			"Perception",
			"Ability to notice details",
			0f ));

		// experience
		stats.Add ( new Stat (
			"Combat",
			"General combat experience",
			0f ));
		stats.Add ( new Stat (
			"Stealth",
			"Ability to remain undetected by nearby others",
			0f ));
		stats.Add ( new Stat (
			"World Knowledge",
			"General knowledge of state of afairs, important persons, customs and geography",
			0f ));
		stats.Add ( new Stat (
			"History Knowledge",
			"General knowledge of past events",
			0f ));
		stats.Add ( new Stat (
			"Science Knowledge",
			"General knowledge of sciences and technology",
			0f ));

		// personal
		stats.Add ( new Stat (
			"Ruthlesness",
			"Tendency to take morraly wrong actions",
			0f ));
		stats.Add ( new Stat (
			"Kindness",
			"Tendency to help others",
			0f ));
		stats.Add ( new Stat (
			"Sanity",
			"Tendency to make rational decisions",
			0f ));
	}

	public Stat FindStat ( Stat stat ) {
		foreach ( Stat s in stats ) {
			if ( s.SameAs ( stat ) )
				return s;
		}
		return null;
	}

	public Stat FindStat ( string name ) {
		Stat s = new Stat ( name, "", 0f );
		return FindStat ( s );
	}
}

[System.Serializable]
public class Stat {

	// stat name
	string name;
	// stat description
	string description;
	// stat's numerical value
	float value;

	public string Name { get { return name; } }

	public string Description { get { return description; } }

	public float Value { get { return value; } }

	public void Set ( float value ) {
		this.value = value;
	}

	public void Modify ( float value ) {
		this.value += value;
	}

	public Stat (string name, string description, float startingValue) {
		this.name = name;
		this.description = description;
		value = startingValue;
	}

	// comparisons

	public bool SameAs ( Stat other ) {
		return name == other.name;
	}

	public override bool Equals ( object obj ) {
		return Equals ( obj as Stat );
	}

	public override int GetHashCode ( ) {
		return this == null ? 0 : GetHashCode ();
	}

	public static bool operator == ( Stat first, Stat second ) {
		return first.Value == second.Value;
	}

	public static bool operator != ( Stat first, Stat second ) {
		return first.Value != second.Value;
	}

	public static bool operator < ( Stat first, Stat second ) {
		return first.Value < second.Value;
	}

	public static bool operator > ( Stat first, Stat second ) {
		return first.Value > second.Value;
	}

	public static bool operator <= ( Stat first, Stat second ) {
		return first.Value <= second.Value;
	}

	public static bool operator >= ( Stat first, Stat second ) {
		return first.Value >= second.Value;
	}
}