using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Reward {
	public abstract void Collect ( Character character );
}

[System.Serializable]
public class CharacterStatReward : Reward {

	Stat stat;
	public Stat Stat { get { return stat; } }

	public CharacterStatReward ( Stat stat ) {
		this.stat = stat;
	}

	public override void Collect ( Character character ) {
		throw new NotImplementedException ( );
	}
}

[System.Serializable]
public class ItemStatReward : Reward {

	Stat stat;
	public Stat Stat { get { return stat; } }

	Item item;
	public Item Item { get { return item; } }

	public ItemStatReward ( Stat stat, Item item ) {
		this.stat = stat;
		this.item = item;
	}

	public override void Collect ( Character character ) {
		throw new NotImplementedException ( );
	}
}

[System.Serializable]
public class ItemReward : Reward {

	Item item;
	public Item Item { get { return item; } }

	public ItemReward ( Item item ) {
		this.item = item;
	}

	public override void Collect ( Character character ) {
		throw new NotImplementedException ( );
	}
}
