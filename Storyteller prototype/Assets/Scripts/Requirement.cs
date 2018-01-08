using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Requirement {
	public abstract bool Test ( Character character );
}

// 1. Stat requirements

/*[System.Serializable]
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
}*/

[System.Serializable]
public class StatRequirementEqual : Requirement {

	[SerializeField]
	Stat requirement;
	public Stat Requirement { get { return requirement; } }


	public StatRequirementEqual ( Stat requirement ) {
		this.requirement = requirement;
	}

	public override bool Test ( Character character ) {

		Stat stat = character.stats.FindStat ( requirement );

		if ( stat == null ) {
			Debug.Log ( "Passed stat is null." );
			return false;
		}

		return stat == requirement;
	}
}

[System.Serializable]
public class StatRequirementNotEqual : Requirement {

	[SerializeField]
	Stat requirement;
	public Stat Requirement { get { return requirement; } }


	public StatRequirementNotEqual ( Stat requirement ) {
		this.requirement = requirement;
	}

	public override bool Test ( Character character ) {

		Stat stat = character.stats.FindStat ( requirement );

		if ( stat == null ) {
			Debug.Log ( "Passed stat is null." );
			return false;
		}

		return stat != requirement;
	}
}

[System.Serializable]
public class StatRequirementGreater : Requirement {

	[SerializeField]
	Stat requirement;
	public Stat Requirement { get { return requirement; } }


	public StatRequirementGreater ( Stat requirement ) {
		this.requirement = requirement;
	}

	public override bool Test ( Character character ) {

		Stat stat = character.stats.FindStat ( requirement );

		if ( stat == null ) {
			Debug.Log ( "Passed stat is null." );
			return false;
		}

		return stat > requirement;
	}
}

[System.Serializable]
public class StatRequirementLess : Requirement {

	[SerializeField]
	Stat requirement;
	public Stat Requirement { get { return requirement; } }


	public StatRequirementLess ( Stat requirement ) {
		this.requirement = requirement;
	}

	public override bool Test ( Character character ) {

		Stat stat = character.stats.FindStat ( requirement );

		if ( stat == null ) {
			Debug.Log ( "Passed stat is null." );
			return false;
		}

		return stat < requirement;
	}
}

[System.Serializable]
public class StatRequirementGreaterEqual : Requirement {

	[SerializeField]
	Stat requirement;
	public Stat Requirement { get { return requirement; } }


	public StatRequirementGreaterEqual ( Stat requirement ) {
		this.requirement = requirement;
	}

	public override bool Test ( Character character ) {

		Stat stat = character.stats.FindStat ( requirement );

		if ( stat == null ) {
			Debug.Log ( "Passed stat is null." );
			return false;
		}

		return stat >= requirement;
	}
}

[System.Serializable]
public class StatRequirementLessEqual : Requirement {

	[SerializeField]
	Stat requirement;
	public Stat Requirement { get { return requirement; } }


	public StatRequirementLessEqual ( Stat requirement ) {
		this.requirement = requirement;
	}

	public override bool Test ( Character character ) {

		Stat stat = character.stats.FindStat ( requirement );

		if ( stat == null ) {
			Debug.Log ( "Passed stat is null." );
			return false;
		}

		return stat <= requirement;
	}
}

// 2.1. Item quantity requirements

/*[System.Serializable]
public class ItemRequirement : Requirement {

	// if the ItemRequirementCase passed to the constructor does not match other arguments default actions will be taken:
	// 1) if the StatRequirement is NOT passed, ItemRequirementCase is changed to hasExactItem
	// 2) if the StatRequirement is passed, ItemRequirementCase is changed to statCheck

	[SerializeField]
	Item requirement;
	public Item RequirementItem { get { return requirement; } }

	[SerializeField]
	ItemRequirementCase itemRequirementCase;
	public ItemRequirementCase RequirementCase { get { return itemRequirementCase; } }

	[SerializeField]
	StatRequirement statRequirement;
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
}*/

// TODO: Implement sharing item results across requirements

[System.Serializable]
public class ItemQuantityRequirementEqual : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	int quantity;
	public int Quantity { get { return quantity; } }

	public ItemQuantityRequirementEqual ( Item item, int quantity ) {
		this.item = item;
		this.quantity = quantity;
	}

	public override bool Test ( Character character ) {

		return character.equipment.FindEquipment ( item.Tags ).Count == quantity;
	}
}

[System.Serializable]
public class ItemQuantityRequirementNotEqual : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	int quantity;
	public int Quantity { get { return quantity; } }

	public ItemQuantityRequirementNotEqual ( Item item, int quantity ) {
		this.item = item;
		this.quantity = quantity;
	}

	public override bool Test ( Character character ) {

		return character.equipment.FindEquipment ( item.Tags ).Count != quantity;
	}
}

[System.Serializable]
public class ItemQuantityRequirementGreater : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	int quantity;
	public int Quantity { get { return quantity; } }

	public ItemQuantityRequirementGreater ( Item item, int quantity ) {
		this.item = item;
		this.quantity = quantity;
	}

	public override bool Test ( Character character ) {

		return character.equipment.FindEquipment ( item.Tags ).Count > quantity;
	}
}

[System.Serializable]
public class ItemQuantityRequirementLess : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	int quantity;
	public int Quantity { get { return quantity; } }

	public ItemQuantityRequirementLess ( Item item, int quantity ) {
		this.item = item;
		this.quantity = quantity;
	}

	public override bool Test ( Character character ) {

		return character.equipment.FindEquipment ( item.Tags ).Count < quantity;
	}
}

[System.Serializable]
public class ItemQuantityRequirementGreaterEqual : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	int quantity;
	public int Quantity { get { return quantity; } }

	public ItemQuantityRequirementGreaterEqual ( Item item, int quantity ) {
		this.item = item;
		this.quantity = quantity;
	}

	public override bool Test ( Character character ) {

		return character.equipment.FindEquipment ( item.Tags ).Count >= quantity;
	}
}

[System.Serializable]
public class ItemQuantityRequirementLessEqual : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	int quantity;
	public int Quantity { get { return quantity; } }

	public ItemQuantityRequirementLessEqual ( Item item, int quantity ) {
		this.item = item;
		this.quantity = quantity;
	}

	public override bool Test ( Character character ) {

		return character.equipment.FindEquipment ( item.Tags ).Count <= quantity;
	}
}

// 2.2. Item stat requirements

[System.Serializable]
public class ItemStatRequirementEqual : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	Stat stat;
	public Stat Stat { get { return stat; } }

	public ItemStatRequirementEqual ( Item item, Stat stat ) {
		this.item = item;
		this.stat = stat;
	}


	// TODO: this currently takes only ItemStats into account... fuck bro you dun fckd up
	public override bool Test ( Character character ) {

		List<Item> items = character.equipment.FindEquipment ( item.Tags );

		foreach ( Item i in items ) {
			foreach ( Stat s in i.ItemStats ) {
				if ( s == stat && s.Value == stat.Value )
					return true;
			}
		}

		return false;
	}
}

[System.Serializable]
public class ItemStatRequirementNotEqual : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	Stat stat;
	public Stat Stat { get { return stat; } }

	public ItemStatRequirementNotEqual ( Item item, Stat stat ) {
		this.item = item;
		this.stat = stat;
	}


	public override bool Test ( Character character ) {

		List<Item> items = character.equipment.FindEquipment ( item.Tags );

		foreach ( Item i in items ) {
			foreach ( Stat s in i.ItemStats ) {
				if ( s == stat && s.Value != stat.Value )
					return true;
			}
		}

		return false;
	}
}

[System.Serializable]
public class ItemStatRequirementGreater : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	Stat stat;
	public Stat Stat { get { return stat; } }

	public ItemStatRequirementGreater ( Item item, Stat stat ) {
		this.item = item;
		this.stat = stat;
	}


	public override bool Test ( Character character ) {

		List<Item> items = character.equipment.FindEquipment ( item.Tags );

		foreach ( Item i in items ) {
			foreach ( Stat s in i.ItemStats ) {
				if ( s == stat && s > stat )
					return true;
			}
		}

		return false;
	}
}

[System.Serializable]
public class ItemStatRequirementLess : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	Stat stat;
	public Stat Stat { get { return stat; } }

	public ItemStatRequirementLess ( Item item, Stat stat ) {
		this.item = item;
		this.stat = stat;
	}


	public override bool Test ( Character character ) {

		List<Item> items = character.equipment.FindEquipment ( item.Tags );

		foreach ( Item i in items ) {
			foreach ( Stat s in i.ItemStats ) {
				if ( s == stat && s < stat )
					return true;
			}
		}

		return false;
	}
}

[System.Serializable]
public class ItemStatRequirementGreaterEqual : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	Stat stat;
	public Stat Stat { get { return stat; } }

	public ItemStatRequirementGreaterEqual ( Item item, Stat stat ) {
		this.item = item;
		this.stat = stat;
	}


	public override bool Test ( Character character ) {

		List<Item> items = character.equipment.FindEquipment ( item.Tags );

		foreach ( Item i in items ) {
			foreach ( Stat s in i.ItemStats ) {
				if ( s == stat && s >= stat )
					return true;
			}
		}

		return false;
	}
}

[System.Serializable]
public class ItemStatRequirementLessEqual : Requirement {

	[SerializeField]
	Item item;
	public Item Item { get { return item; } }

	[SerializeField]
	Stat stat;
	public Stat Stat { get { return stat; } }

	public ItemStatRequirementLessEqual ( Item item, Stat stat ) {
		this.item = item;
		this.stat = stat;
	}


	public override bool Test ( Character character ) {

		List<Item> items = character.equipment.FindEquipment ( item.Tags );

		foreach ( Item i in items ) {
			foreach ( Stat s in i.ItemStats ) {
				if ( s == stat && s <= stat )
					return true;
			}
		}

		return false;
	}
}

/*public enum Comparison {
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
}*/
