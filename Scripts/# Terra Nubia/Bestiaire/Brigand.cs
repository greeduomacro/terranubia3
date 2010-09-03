using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	public class Brigand : NubiaCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public Brigand() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "le brigand";
            Hue = Utility.RandomList(new int[] { 1025, 1032, 1049, 1057, 1878 });

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 401;
				Name = NameList.RandomName( "female" );
				AddItem( new Skirt( Utility.RandomNeutralHue() ) );
			}
			else
			{
				Body = 400;
				Name = NameList.RandomName( "male" );
				AddItem( new ShortPants( Utility.RandomNeutralHue() ) );
			}

            if (Utility.RandomDouble() > .8)
            {
                int hueOrc =  Utility.RandomList( new int[]{ 1450,1451,1452,2420,1441,1442,1443,1444,1025,1032,1049,1057,1878 } );
                TNRaceSkinHalforc skin = new TNRaceSkinHalforc(hueOrc);
                this.Hue = hueOrc;
                skin.Movable = false;
                AddItem(skin);
            }
			
			AddItem( new Boots( Utility.RandomNeutralHue() ) );
            if (Utility.RandomBool())
                AddItem(new Shirt());
            else
                AddItem(new LeatherChest());

			AddItem( new Bandana());

			switch ( Utility.Random( 7 ))
			{
				case 0: AddItem( new Longsword() ); break;
				case 1: AddItem( new Cutlass() ); break;
				case 2: AddItem( new Broadsword() ); break;
				case 3: AddItem( new Axe() ); break;
				case 4: AddItem( new Club() ); break;
				case 5: AddItem( new Dagger() ); break;
				case 6: AddItem( new Spear() ); break;
			}

            mMonsterHits = DndHelper.rollDe(De.huit, 2) + 4;
            this.VirtualArmor = 15;
            mMonsterAttaques = new int[] { 2, -2 };
        
            mMonsterCA = VirtualArmor;

            mMonsterReflexe = 1;
            mMonsterVigueur = 5;
            mMonsterVolonte = 1;
            RawStr = 13;
            RawDex = 15;
            RawCons = 15;
            RawInt = 2;
            RawSag = 12;
            RawCha = 6;

            AddCompetence(CompType.Detection, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.DeplacementSilencieux, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.Survie, 1);
            mMonsterNiveau = 3;

			//Utility.AssignRandomHair( this );
            NubiaHelper.RandomHair(this);

            VirtualArmor = 3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public Brigand( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}