﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SimpleGame
{
	[Serializable]
	public class Weapon : Item, ISerializable
	{
		private int damage;
		private DamageType damageType;
		private Abilities.ItemAbility proc;
		
		public Weapon(int itemid): base(itemid)
		{
			this.damage = int.Parse(ItemStats.GetStat(itemid, "damage"));
			this.picture = SimpleGame.Properties.Resources.weapon_image;
			this.proc = null;
		}

		public Weapon(SerializationInfo info, StreamingContext ctxt): base(info, ctxt)
		{
			this.damage = (int)info.GetValue("damage", typeof(int));
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);
			info.AddValue("damage", this.damage);
		}

		public int Damage
		{
			get { return damage; }
		}
		public DamageType DamageType
		{
			get { return damageType; }
		}
		public Ability Proc
		{
			get { return proc; }
		}
	}
}