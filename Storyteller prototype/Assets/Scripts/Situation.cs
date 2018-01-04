using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Situation : ScriptableObject {

	// list of all situations
	protected static List<Situation> allSituations;
	public static List<Situation> AllSituations { get { return allSituations; } }

	[SerializeField]
	private SituationStep initialStep;
	public SituationStep InitialStep { get { return initialStep; } }

	// requirements

	[SerializeField]
	private List<Requirement> requirements;
	public List<Requirement> Requirements { get { return requirements; } }

	// TODO: reward (modifier, equipment, quest)

	public Situation ( SituationStep initialStep, List<Requirement> requirements/*, List<RewardPackage> rewards*/ ) {
		this.initialStep = initialStep;
		this.requirements = requirements;
	}

	public bool CheckRequirements ( Character character ) {
		foreach ( Requirement r in requirements ) {
			return r.Test ( character );
		}
		// default to true if no requirements present
		return true;
	}

	public void DeleteForever ( ) {
		allSituations.Remove ( this );
		// TODO: implement removing from json file
	}
}

[System.Serializable]
public class SituationStep {

	// name of the situation
	[SerializeField]
	private string name;
	public string Name { get { return name; } }

	// description text
	[SerializeField]
	private string description;
	public string Description { get { return description; } }

	// options
	[SerializeField]
	private List<SituationStepPackage> options;
	public List<SituationStepPackage> Options { get { return options; } }

	public SituationStep ( string name, string description, List<SituationStepPackage> options ) {
		this.name = name;
		this.description = description;
		this.options = options;
	}

	public void DeleteForever ( ) {
		// TODO: implement removing from json file
	}
}

[System.Serializable]
public class SituationStepPackage {

	// name of the option package
	[SerializeField]
	private string name;
	public string Name { get { return name; } }

	// TODO: maybe add different levels of success/failiure eventually
	[SerializeField]
	private SituationStep successStep;
	public SituationStep SuccessStep { get { return successStep; } }

	[SerializeField]
	private SituationStep failiureStep;
	public SituationStep FailiureStep { get { return failiureStep; } }

	// requirements
	[SerializeField]
	private List<Requirement> requirements;
	public List<Requirement> Requirements { get { return requirements; } }

	// TODO: reward (modifier, equipment)
	
	public bool CheckRequirements ( Character character ) {
		foreach ( Requirement r in requirements ) {
			return r.Test ( character );
		}
		// default to true if no requirements present
		return true;
	}

	public void DeleteForever ( ) {
		// TODO: implement removing from json file
	}
}
