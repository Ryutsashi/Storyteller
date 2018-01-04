using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Requirement {
	public abstract bool Test ( Character character );
}

[System.Serializable]
public class StatRequirement : Requirement {
	[SerializeField]
	Stat requirement;
	[SerializeField]
	Comparison comparison;

	public Stat Requirement { get { return requirement; } }

	public Comparison Comparison { get { return comparison; } }

	public StatRequirement ( Stat requirement, Comparison comparisonMode ) {
		this.requirement = requirement;
		comparison = comparisonMode;
	}

	public override bool Test ( Character character ) {

		Stat stat = character.stats.FindStat ( requirement );
		if ( stat != null ) {
			switch ( comparison ) {
				case Comparison.equals:
					return IsEqual ( stat );
				case Comparison.notEquals:
					return !IsEqual ( stat );
				case Comparison.less:
					return IsLess ( stat );
				case Comparison.greater:
					return IsGreater ( stat );
				case Comparison.lessEquals:
					return IsLess ( stat ) && IsEqual ( stat );
				case Comparison.greaterEquals:
					return IsGreater ( stat ) && IsEqual ( stat );
				default:
					break;
			}
		}
		return false;
	}

	public bool IsEqual ( Stat stat ) {
		return stat == requirement;
	}

	public bool IsLess ( Stat stat ) {
		return stat < requirement;
	}

	public bool IsGreater ( Stat stat ) {
		return stat > requirement;
	}
}

[System.Serializable]
public class ItemRequirement : Requirement {

	// if the ItemRequirementCase passed to the constructor does not match other arguments default actions will be taken:
	// 1) if the StatRequirement is NOT passed, ItemRequirementCase is changed to hasExactItem
	// 2) if the StatRequirement is passed, ItemRequirementCase is changed to statCheck

	[SerializeField]
	Item requirement;
	[SerializeField]
	ItemRequirementCase itemRequirementCase;
	[SerializeField]
	StatRequirement statRequirement;

	public Item RequirementItem { get { return requirement; } }

	public ItemRequirementCase RequirementCase { get { return itemRequirementCase; } }

	public StatRequirement StatRequirement { get { return statRequirement; } }

	public ItemRequirement ( Item item, ItemRequirementCase itemRequirementCase ) {
		if ( itemRequirementCase == ItemRequirementCase.statCheck )
			itemRequirementCase = ItemRequirementCase.hasExactItem;
		this.itemRequirementCase = itemRequirementCase;
		requirement = item;
	}

	public ItemRequirement ( Item item, ItemRequirementCase itemRequirementCase, StatRequirement statRequirement ) {
		if ( itemRequirementCase != ItemRequirementCase.statCheck )
			itemRequirementCase = ItemRequirementCase.statCheck;
		this.itemRequirementCase = itemRequirementCase;
		requirement = item;
		this.statRequirement = statRequirement;
	}

	public override bool Test ( Character character ) {
		switch ( itemRequirementCase ) {
			case ItemRequirementCase.hasTag:
				return HasTag( character );
			case ItemRequirementCase.notHasTag:
				return !HasTag ( character );
			case ItemRequirementCase.hasExactItem:
				return HasItem ( character );
			case ItemRequirementCase.notHasExactItem:
				return !HasItem ( character );
			case ItemRequirementCase.statCheck:
				return StatCheck ( character );
			default:
				return true;
		}
	}

	bool HasTag ( Character character ) {
		return character.equipment.FindEquipment ( requirement.Tags ).Count > 0;
	}

	bool HasItem ( Character character ) {
		return character.equipment.FindEquipment ( requirement ).Count > 0;
	}

	bool StatCheck ( Character character ) {
		List<Item> itemList = character.equipment.FindEquipment ( requirement.Tags );
		itemList.AddRange ( character.equipment.FindEquipment ( requirement ) );
		foreach ( Item i in itemList ) {
			List<Stat> itemStats = i.ItemStats;
			List<Stat> finalStats = new List<Stat> ( );
			foreach ( Stat s in itemStats ) {
				if ( s == statRequirement.Requirement )
					finalStats.Add ( s );
			}
			foreach ( Stat s in finalStats ) {
				switch ( statRequirement.Comparison ) {
					case Comparison.equals:
						return statRequirement.IsEqual ( statRequirement.Requirement );
					case Comparison.notEquals:
						return !statRequirement.IsEqual ( statRequirement.Requirement );
					case Comparison.less:
						return statRequirement.IsLess ( statRequirement.Requirement );
					case Comparison.greater:
						return statRequirement.IsGreater ( statRequirement.Requirement );
					case Comparison.lessEquals:
						return statRequirement.IsLess ( statRequirement.Requirement )
							&& statRequirement.IsEqual ( statRequirement.Requirement );
					case Comparison.greaterEquals:
						return statRequirement.IsGreater ( statRequirement.Requirement )
							&& statRequirement.IsEqual ( statRequirement.Requirement );
					default:
						break;
				}
			}
		}
		return false;
	}
}

public enum Comparison {
	equals,
	notEquals,
	less,
	greater,
	lessEquals,
	greaterEquals
}

public enum ItemRequirementCase {
	hasTag,
	notHasTag,
	hasExactItem,
	notHasExactItem,
	statCheck
}