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

	List<Stat> itemStats = new List<Stat> ( );

	Character owner;

	string name;
	string description;
	List<ItemTag> tags;

	// bonus effect by simply having the item
	List<Stat> statModifiers;
	// bonus effect over time (eg. health regeneration)
	List<Stat> passiveBonus;
	// bonus effect when activating the item (eg. potion that grants temporary strength)
	List<Stat> activeBonus;

	public Character Owner { get { return owner; } }

	public void ChangeOwner ( Character newOwner ) {
		owner = newOwner;
	}

	public string Name { get { return name; } }

	public string Description { get { return description; } }

	public List<ItemTag> Tags { get { return tags; } }

	public List<Stat> ItemStats { get { return itemStats; } }

	public List<Stat> StatModifiers { get { return statModifiers; } }

	public List<Stat> PassiveBonus { get { return passiveBonus; } }

	public List<Stat> ActiveBonus { get { return activeBonus; } }

	public Item ( string name, string description, List<ItemTag> tags ) {
		owner = null;
		passiveBonus = new List<Stat> ( );
		activeBonus = new List<Stat> ( );
		this.tags = tags;
		itemStats.Add ( new Stat (
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
				0.1f ) );
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