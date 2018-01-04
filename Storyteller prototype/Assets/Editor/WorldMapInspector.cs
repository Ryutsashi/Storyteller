using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(WorldMap))]
public class WorldMapInspector : Editor {

	WorldMap obj;

	StateMachine map;
	List<State> locations;

	State openLocation;

	string search;

	private void OnEnable ( ) {
		obj = ( WorldMap ) target;
		map = obj.map;
		openLocation = null;
	}

	public override void OnInspectorGUI ( ) {

		locations = map.GetAllStates ( );

		string currentState = map.GetCurrentState ( );
		if ( currentState == "" )
			currentState = "location_name_missing";

		List<State> filteredLocations;
		if ( search != null )
			filteredLocations = FilterLocations ( );
		else
			filteredLocations = locations;

		// title
		GUILayout.Label ( "World Map" );
		GUILayout.Space ( 20 );

		// current locations
		GUILayout.Label ( "Current location:\t" + currentState );

		// filter bar
		GUILayout.BeginHorizontal ( );
		GUILayout.Label ( "Filter All Locations ( " + filteredLocations.Count + " / " + locations.Count + " )" );
		if ( GUILayout.Button ( "Add Location", GUILayout.MaxWidth ( 100 ) ) ) {
			string [ ] array = new string [ 1 ] ;
			array [ 0 ] = "";
			map.AddState ( "", array );
		}
		search = GUILayout.TextField ( search, GUILayout.MinWidth ( 80 ) );
		GUILayout.EndHorizontal ( );
		GUILayout.Space ( 10 );

		// locations
		for (int i = 0; i < filteredLocations.Count; i++ ) {
			List<string> links = filteredLocations [ i ].Links;

			if ( openLocation == filteredLocations [ i ] ) {

				GUILayout.Space ( 20 );

				// title
				GUILayout.BeginHorizontal ( );
			
				if ( GUILayout.Button ( "Remove", GUILayout.MaxWidth ( 80 ) ) ) {
					map.RemoveState ( filteredLocations [ i ].Name );
				}

				EditorGUI.BeginChangeCheck ( );
				string locationName = GUILayout.TextField ( filteredLocations [ i ].Name, GUILayout.MinWidth ( 100 ) );
				if ( EditorGUI.EndChangeCheck ( ) ) {
					filteredLocations [ i ].Rename ( locationName );
				}

				if ( GUILayout.Button ( "Close", GUILayout.MaxWidth ( 50 ) ) ) {
					openLocation = null;
					return;
				}
				GUILayout.EndHorizontal ( );
				GUILayout.Space ( 10 );

				// location links
				GUILayout.BeginHorizontal ( );
				if ( links.Count > 0 ) {
					GUILayout.Label ( "Links:" );
				}
				else {
					GUILayout.Label ( "No Links" );
				}
				if ( GUILayout.Button ( "+", GUILayout.MaxWidth ( 20 ) ) ) {
					filteredLocations [ i ].AddLink ( "" );
				}
				GUILayout.EndHorizontal ( );
				for ( int j = 0; j < links.Count; j++ ) {
					GUILayout.BeginHorizontal ( );
					GUILayout.Space ( 20 );
					EditorGUI.BeginChangeCheck ( );
					string linkName = GUILayout.TextField ( links [ j ] );
					if ( EditorGUI.EndChangeCheck ( ) ) {
						filteredLocations [ i ].ModifyLink ( j, linkName );
					}
					if ( GUILayout.Button ( "-", GUILayout.MaxWidth ( 20 ) ) ) {

						filteredLocations [ i ].RemoveLink ( links [ j ] );
					}
					GUILayout.EndHorizontal ( );
				}
				GUILayout.Space ( 20 );
			}
			else {
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ( filteredLocations [ i ].Name );
				if ( openLocation == null && GUILayout.Button ( "Edit", GUILayout.MaxWidth ( 50 ) ) ) {
					openLocation = filteredLocations [ i ];
					return;
				}
				GUILayout.EndHorizontal ( );
			}
			GUILayout.Space ( 5 );
		}

		//base.OnInspectorGUI ( );
	}

	List<State> FilterLocations () {
		List<State> filtered = new List<State> ( );
		foreach (State l in locations) {
			if ( l.Name.ToLower().Contains ( search ) )
				filtered.Add ( l );
		}
		return filtered;
	}
}
