using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldMap : ScriptableObject {

	public static List<MapLocation> locations;

	public static void AddLocation ( MapLocation location ) {
		if ( !locations.Contains ( location ) ) {
			locations.Add ( location );
		}
	}
}

// This is a unique location used for physical objects it can be a Character, an Item or a MapLocation.
//		As a Character StorageLocation it is shared by all the items that a Character has on them (clothing, inventory...)
//		As an Item StorageLocation it is shared by all the items bound to that item (a potion in a backpack, a coin in a purse...)
//		As a MapLocation StorageLocation it is shared by all the items in that area (a note on the floor, a meal in a shop...)

//		SHIT SHIT SHIT SHIT NOT SURE HOW TO WHAT TO FUCK THIS FOR NOW

/*public class StorageLocation {

	public static List<StorageLocation> allStorageLocations;

	public Character c;
	public Character Character { get { return c; } }
	public Item i;
	public Item Item { get { return i; } }
	public MapLocation m;
	public MapLocation MapLocation { get { return m; } }

	public StorageLocation ( Character character ) {
		Init ( );

		foreach ( StorageLocation l in allStorageLocations ) {
			if ( l.Character == character ) {

			}
		}

		c = character;
	}

	public void Init ( ) {
		if ( allStorageLocations == null ) {
			allStorageLocations = new List<StorageLocation> ( );
		}
	}
}*/

[System.Serializable]
public class MapLocation {
	[SerializeField]
	string name;
	public string Name { get { return name; } }

	[SerializeField]
	string description;
	public string Description { get { return description; } }

	[SerializeField]
	List<LocationTag> tags;
	public List<LocationTag> Tags { get { return tags; } }
	public void AddTag ( LocationTag tag ) {
		foreach ( LocationTag t in tags ) {
			if ( t == tag )
				return;
		}
		tags.Add ( tag );
	}
	public void RemoveTag ( LocationTag tag ) {
		foreach ( LocationTag t in tags ) {
			if ( t == tag )
				tags.Remove ( tag );
		}
	}

	[SerializeField]
	List<MapPortal> portals;
	public List <MapPortal> Portals { get { return portals; } }
	public void AddPortal ( MapPortal portal ) {
		foreach ( MapPortal p in portals ) {
			if ( p == portal )
				return;
		}
		portals.Add ( portal );
	}
	public void RemovePortal ( MapPortal portal ) {
		foreach ( MapPortal p in portals) {
			if ( p == portal )
				portals.Remove ( portal );
		}
	}

	public MapLocation ( string name, string description, List<LocationTag> tags ) {
		this.name = name;
		this.description = description;
		this.tags = tags;
	}
}

public class MapPortal {
	[SerializeField]
	MapLocation location;
	public MapLocation Location { get { return location; } }

	[SerializeField]
	float distanceFromCenter = 1f;
	public float DistanceFromCenter { get { return distanceFromCenter; } }
	public void AdjustDistance ( float newDistance ) {
		distanceFromCenter = newDistance;
	}

	[SerializeField]
	bool isLocked = false;
	public bool Locked { get { return isLocked; } }
	public void Lock ( ) {
		isLocked = true;
	}
	public void Unlock ( ) {
		isLocked = false;
	}

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
