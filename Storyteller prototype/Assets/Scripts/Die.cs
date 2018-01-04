using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die {

	public static int Roll ( int variance ) {
		return Mathf.RoundToInt ( Random.Range ( 0f, 1f ) * variance );
	}

	public static int Roll ( int variance, Difficulty difficulty ) {
		float result;
		switch ( difficulty ) {
			case Difficulty.hard:
				result = ( Random.Range ( 0f, 1f ) + Random.Range ( 0f, 1f ) + Random.Range ( 0f, 1f ) ) / 3;
				break;
			case Difficulty.normal:
				result = ( Random.Range ( 0f, 1f ) + Random.Range ( 0f, 1f ) ) * .5f;
				break;
			case Difficulty.easy:
				result = Random.Range ( 0f, 1f );
				break;
			default:
				result = Random.Range ( 0f, 1f );
				break;
		}
		return Mathf.RoundToInt ( result * variance );
	}
}

public enum Difficulty {
	easy,
	normal,
	hard
}
