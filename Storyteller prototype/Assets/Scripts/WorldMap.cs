using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldMap : ScriptableObject {
	public List<MapLocation> locations = new List<MapLocation> ( );
}

[System.Serializable]
public class MapLocation {
	[SerializeField]
	string name;
	[SerializeField]
	string description;
	[SerializeField]
	List<LocationTag> tags;
	[SerializeField]
	List<MapPortal> portals;

	public MapLocation ( string name, string description, List<LocationTag> tags, List<MapPortal> portals ) {
		this.name = name;
		this.description = description;
		this.tags = tags;
		this.portals = portals;
	}
}

public class MapPortal {
	[SerializeField]
	MapLocation location;
	[SerializeField]
	float distanceFromCenter = 1f;
	[SerializeField]
	bool isLocked = false;

	public MapPortal ( MapLocation leadsTo, float distanceFromCenter, bool isLocked = false ) {
		location = leadsTo;
		this.distanceFromCenter = distanceFromCenter;
		this.isLocked = isLocked;
	}
}

public enum LocationTag {
	// danger level
	Dangerous,
		LowSecurity,
		Wilderness,
	Safe,
	VerySafe,
		Guarded,
	// geography zones
	Heart,
	Slums,
	Rim,
	UpperLevels,
	MiddleLevels,
	LowerLevels,
	ShallowTunnels,
	DeepTunnels,
	// faction territory
	FactionTerritory,
		PrivateProperty,
		CityGuard,
		BlacksteelGang,
		RedBarons,
		PeoplesArmy,
		CultOfTheVoid,
		ChurchOfMan,
		TheHooks,
	// environment
	City,
		Street,
		Square,
		DeadEnd,
		BackAlley,
		Garden,
	Bridge,
	Cave,
	Building,
		Shack,
		House,
		Palace,
		Inn,
		Bank,
		Church,
		Factory,
		Farm,
	// light level
	WellLit,
	LowLight,
	Dark,
	// general
	Underwater,
	WaterSurface,
	Windy,
	PoisonousAir,
	// temperature
	Hot,
	Cold,
	// humidity
	Dry,
	Humid
}
