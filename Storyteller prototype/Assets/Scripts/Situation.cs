using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Situation : ScriptableObject {

	public SituationStep initialStep;
	// requirements
	// reward (modifier, equipment, quest)

}

[System.Serializable]
public class SituationStep {

	// name of the option/situation
	public string name;
	// description text
	public string description;
	// options
	public List<SituationStep> options;
}

[System.Serializable]
public class SituationStepPackage {

	public SituationStep onSuccess;
	public SituationStep onFailiure;
	// requirements
	// reward (modifier, equipment)
}
