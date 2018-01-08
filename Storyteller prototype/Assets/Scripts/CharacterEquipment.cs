using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment {

	public List<Item> equipment;

	public List<Item> FindEquipment ( Item item ) {
		List<Item> matches = new List<Item> ( );
		foreach (Item i in equipment) {
			if ( i.Name == item.Name )
				matches.Add ( i );
		}
		return matches;
	}

	public List<Item> FindEquipment ( List<ItemTag> tags ) {
		List<Item> matches = new List<Item> ( );
		foreach ( Item i in equipment ) {
			foreach ( ItemTag t in tags ) {
				if ( !i.Is ( t ) )
					break;
				matches.Add ( i );
			}
		}
		return matches;
	}
}

[System.Serializable]
public class Item {
	
	// item name
	string name;
	public string Name { get { return name; } }

	// item description
	string description;
	public string Description { get { return description; } }

	// descriptive tags
	List<ItemTag> tags;
	public List<ItemTag> Tags { get { return tags; } }

	// owner of the item
	Character owner;
	public Character Owner { get { return owner; } }
	public void ChangeOwner ( Character newOwner ) {
		owner = newOwner;
	}

	// inherent stats like durability or weight
	List<Stat> itemStats = new List<Stat> ( );
	public List<Stat> ItemStats { get { return itemStats; } }
	public void AddItemStat ( Stat stat ) {
		foreach ( Stat s in itemStats ) {
			if ( s == stat )
				return;
		}
		itemStats.Add ( stat );
	}
	public void RemoveItemStat ( Stat stat ) {
		foreach ( Stat s in itemStats ) {
			if ( s == stat )
				itemStats.Remove ( s );
		}
	}

	// bonus effect by simply having the item
	List<Stat> statModifiers;
	public List<Stat> StatModifiers { get { return statModifiers; } }
	public void AddStatModifiers ( Stat stat ) {
		foreach ( Stat s in statModifiers ) {
			if ( s == stat )
				return;
		}
		statModifiers.Add ( stat );
	}
	public void RemoveStatModifiers ( Stat stat ) {
		foreach ( Stat s in statModifiers ) {
			if ( s == stat )
				statModifiers.Remove ( s );
		}
	}

	// bonus effect over time (eg. health regeneration)
	List<Stat> passiveBonus;
	public List<Stat> PassiveBonus { get { return passiveBonus; } }
	public void AddPassiveBonus ( Stat stat ) {
		foreach ( Stat s in passiveBonus ) {
			if ( s == stat )
				return;
		}
		passiveBonus.Add ( stat );
	}
	public void RemovePassiveBonus ( Stat stat ) {
		foreach ( Stat s in passiveBonus ) {
			if ( s == stat )
				passiveBonus.Remove ( s );
		}
	}

	// bonus effect when activating the item (eg. potion that grants temporary strength)
	List<Stat> activeBonus;
	public List<Stat> ActiveBonus { get { return activeBonus; } }
	public void AddActiveBonus ( Stat stat ) {
		foreach ( Stat s in activeBonus ) {
			if ( s == stat )
				return;
		}
		activeBonus.Add ( stat );
	}
	public void RemoveActiveBonus ( Stat stat ) {
		foreach ( Stat s in activeBonus ) {
			if ( s == stat )
				activeBonus.Remove ( s );
		}
	}

	// TODO: implement "LocatedAt" item variable

	// TODO: Add item requirements

	public Item ( string name, string description, List<ItemTag> tags ) {
		owner = null;
		passiveBonus = new List<Stat> ( );
		activeBonus = new List<Stat> ( );
		this.tags = tags;

		/*itemStats.Add ( new Stat (
				"Durability",
				"Item durability",
				100f ) );
		itemStats.Add ( new Stat (
				"Maximum Durability",
				"Maximum item durability when undamaged",
				100f ) );
		itemStats.Add ( new Stat (
				"Weight",
				"Item weight in kilos (kg)",
				0.1f ) );*/
	}

	public bool Is ( ItemTag tag ) {
		foreach ( ItemTag t in tags ) {
			if ( t == tag )
				return true;
		}
		return false;
	}
}

public enum ItemTag {
	// wearables
	Wearable,
		Clothing,
			Shirt,
			Pants,
			Shoes,
			Hat,
		Trinket,
			Ring,
			Necklace,
			Key,
		Armor,
			Chest,
			Arm,
			Gloves,
			Helmet,
			Legs,
			Feet,
	// tools and weapons
	Handheld,
		Weapon,
			SingleHanded,
				ShortSword,
				Axe,
				Mace,
				Whip,
			TwoHanded,
				LongSword,
				Pike,
				Polearm,
				BattleAxe,
		Shield,
			SmallShield,
			LargeShield,
	// consumables
	Consumable,
		Food,
		Water,
		Potion,
		Toxin,
	// materials
	Material,
		Raw,
			Ore,
				Iron,
				Gold,
				Silver,
			Wood,
			Crystal,
		Processed,
			Fabric,
			Leather,
			Organic,
	// weight
	Light,
	Heavy,
	// size
	Large,
	Small,
	// damage
	Piercing,
	Slashing,
	Blunt,
	Elemental,
	// form
	Solid,
	Liquid,
	Gas,
	Ethereal
}