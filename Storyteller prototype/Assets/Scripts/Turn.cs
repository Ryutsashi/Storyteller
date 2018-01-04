using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Turn {

	delegate void TurnStateDelegate ( );
	//delegate void TimePassesDelegate ( int time );

	// State events
	static event TurnStateDelegate pickGoalEvent;
	static event TurnStateDelegate startSituationEvent;
	static event TurnStateDelegate pickActionEvent;

	//static event TimePassesDelegate simulateWorldEvent;
	

	/*
	pick situation
	
	pick resolution

	calculate result

	apply modifiers

	simulate world and other characters

	end of turn

	goto1
	*/
}
