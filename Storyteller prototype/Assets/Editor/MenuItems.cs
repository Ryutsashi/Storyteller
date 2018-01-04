using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems : MonoBehaviour {

	[MenuItem("Assets/Create/WorldMap")]
	public static void CreateMapAsset () {
		WorldMap map = ScriptableObject.CreateInstance<WorldMap> ( );
		AssetDatabase.CreateAsset ( map, "Assets/Resources/WorldMap.asset" );
		AssetDatabase.SaveAssets ( );
	}
}
