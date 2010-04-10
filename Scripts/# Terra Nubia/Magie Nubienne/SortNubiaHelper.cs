using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Spells
{
	public static class SortNubiaHelper
	{
        public static string formatName(SortNubia sort)
        {
            return SortNubiaHelper.getDomaineString(sort.Domaine) + ": " + sort.DefaultName;
        }

        public static double calculMaitriseEnergie(SortEnergie energie, SortEnergie enerMaitre)
        {
            return calculMaitriseEnergie(energie, enerMaitre, MageSpe.Normal);
        }

        public static double calculMaitriseEnergie(SortEnergie energie, SortEnergie enerMaitre, MageSpe magespe)
        {
            
                double p = 0;
                int ecart = 0;

                if (energie != enerMaitre)
                {

                    int inc = 0;
                    int dec = 0;
                    ecart++;
                    int count = (int)SortEnergie.Maximum - (int)(SortEnergie.All + 1);

                    for (int rang = (int)enerMaitre; inc <= count; rang++)
                    {
                        if ((SortEnergie)rang == energie)
                            break;
                        //    inc++;
                        if (rang >= (int)SortEnergie.Maximum)
                            rang = (int)SortEnergie.All;
                        else
                            inc++;
                    }
                    for (int rang = (int)(enerMaitre); dec <= count; rang--)
                    {

                        if ((SortEnergie)rang == energie)
                            break;

                        if (rang <= (int)SortEnergie.All)
                            rang = (int)SortEnergie.Maximum;
                        else
                            dec++;
                    }
                    //     Console.WriteLine(energie.ToString() + "= " + inc + "," + dec);
                    ecart = Math.Min(inc, dec);
                }

                p = algoSelectionSouple(ecart, magespe);                

                return p;
            
        }
        private static double algoSelectionSouple(int ecart, MageSpe magespe)
        {
            double y = 0.0;

            if (magespe == MageSpe.Generaliste)
            {
                switch (ecart)
                {
                    case 0: y = 60 / 1.4; break;
                    case 1: y = 55 / 1.4; break;
                    case 2: y = 50 / 1.4; break;
                    case 3: y = 45 / 1.4; break;
                }
            }
            else if (magespe == MageSpe.Normal)
            {
                switch (ecart)
                {
                    case 0: y = 100 / 1.4; break;
                    case 1: y = 80 / 1.4; break;
                    case 2: y = 50 / 1.4; break;
                }
            }
            else if (magespe == MageSpe.Specialiste)
            {
                switch (ecart)
                {
                    case 0: y = 140 / 1.4; break;
                    case 1: y = 110 / 1.4; break;
                }
            }

            y = Math.Round(y, 1);
            return y;
        }
        public static double calculMaitriseDomaine(SortDomaine domaine, SortDomaine domMaitre)
        {
            return calculMaitriseDomaine(domaine, domMaitre, MageSpe.Normal);
        }
        public static double calculMaitriseDomaine(SortDomaine domaine, SortDomaine domMaitre, MageSpe amplitude)
        {
            {
                double p = 0;

                int ecart = 0;
                if (domaine != domMaitre)
                {
                    int inc = 0;
                    int dec = 0;
                    int count = (int)SortDomaine.Maximum - (int)(SortDomaine.All + 1);

                    for (int rang = (int)domMaitre; inc <= count; rang++)
                    {
                        if ((SortDomaine)rang == domaine)
                            break;
                        //    inc++;
                        if (rang >= (int)SortDomaine.Maximum)
                            rang = (int)SortDomaine.All;
                        else
                            inc++;
                    }
                    for (int rang = (int)(domMaitre); dec <= count; rang--)
                    {

                        if ((SortDomaine)rang == domaine)
                            break;

                        if (rang <= (int)SortDomaine.All)
                            rang = (int)SortDomaine.Maximum;
                        else
                            dec++;
                    }
                    //  Console.WriteLine(domaine.ToString()+"= "+inc + "," + dec);
                    ecart = Math.Min(inc, dec);
                }

                p = algoSelectionSouple(ecart, amplitude);

                return p;

               /* if (p < 0)
                    p = 0;*/
                

                return p;
            }
        }
        public static int getHueForPercent(int percent)
        {
            if (percent >= 100)
                return 163;
            else if (percent >= 80)
                return 158;
            else if (percent >= 60)
                return 153;
            else if (percent >= 40)
                return 148;
            else if (percent >= 20)
                return 143;
            else
                return 138;

        }
        public static string getEnergieString(SortEnergie dom)
        {

            switch (dom)
            {
                case SortEnergie.All: return "Tous";
                case SortEnergie.Air: return "Air";
                case SortEnergie.Eau: return "Eau";
                case SortEnergie.Feu: return "Feu";
                case SortEnergie.Matiere: return "Matières";
                case SortEnergie.Mental: return "Mental";
                case SortEnergie.Mort: return "Mort";
                case SortEnergie.Piege: return "Pièges";
                case SortEnergie.Terre: return "Terre";
                case SortEnergie.Vie: return "Vie";
            }
            return "energie";
        }

        public static string getDomaineString(SortDomaine dom){
            
            switch (dom)
            {
                case SortDomaine.All: return "Tous";
                case SortDomaine.Chimere: return "Chimères";
                case SortDomaine.Evocation: return "Evocation";
                case SortDomaine.Entrave: return "Entrave";
                case SortDomaine.InvocationMatiere: return "Invocation Matière";
                case SortDomaine.InvocationVie: return "Invocation Vie";
                case SortDomaine.Poison: return "Poison";
                case SortDomaine.Abjuration: return "Abjuration";
                case SortDomaine.Soin: return "Soin";
            }
            return "domaine";
        }
		public static int getMur(SortEnergie comp)
		{
			int id = 0x90;
			if( comp == SortEnergie.Mental )
				id = Utility.RandomList(0x3946,0x3956,0x3967,0x3979);
            else if (comp == SortEnergie.Feu)
				id = Utility.RandomList(0x398F,0x3996);
            else if (comp == SortEnergie.Air)
				id = Utility.RandomList(0x3789);
            else if (comp == SortEnergie.Terre)
				id = Utility.RandomList(0x80,0x81,0x82,0x83,0x84,0x85);
            else if (comp == SortEnergie.Terre)
				id = Utility.RandomList(0x37EB);
            else if (comp == SortEnergie.Eau)
				id = Utility.RandomList(0x3709,0x90D);
            else if (comp == SortEnergie.Mort)
				id = Utility.RandomList(0x1A01,0x1A02,0x1A03,0x1A04,0x1A05,0x1A06,0x1A09,0x1A0A,0x1A0B,0x1A0C,0x1A0D,0x1A0E);
            else if (comp == SortEnergie.Mort)
				id = Utility.RandomList(0x124D,0x124B);
            else if (comp == SortEnergie.Mort)
				id = Utility.RandomList(0x373A,0x375A);
            else if (comp == SortEnergie.Vie)
				id = Utility.RandomList(0xD94,0xD98,0x247D,0xCDA,0x224C,0x26ED);

			return id;
		}
		public static void makeBigSmoke(Point3D m, Map map)
		{
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z + 4 ), map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z ), map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z - 4 ), map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z + 4 ), map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z ), map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z - 4 ), map, 0x3728, 13 );

			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 11 ), map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 7 ), map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 3 ), map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z - 1 ), map, 0x3728, 13 );
		}
		public static string getNameEffect(SortNubiaEffect effet)
		{
			switch(effet)
			{
				case SortNubiaEffect.FireBall: return "Boule de feu"; break;
				case SortNubiaEffect.Bee: return "Essain"; break;
				case SortNubiaEffect.BladeSpirit: return "Lames Acéré"; break;
				case SortNubiaEffect.BlueSparkle: return "Scintillement Leger"; break;
				case SortNubiaEffect.BlueGoldSparkle1: return "Scintillement 1"; break;
				case SortNubiaEffect.BlueGoldSparkle2: return "Scintillement 2"; break;
				case SortNubiaEffect.RedSparkle: return "Scintillement aggressif"; break;
				case SortNubiaEffect.Energy: return "Filet d'energie"; break;
				case SortNubiaEffect.Vortex: return "Vortex"; break;
				case SortNubiaEffect.ExplosionBall: return "Boule"; break;
				case SortNubiaEffect.FireSnake: return "Serpentin"; break;
				case SortNubiaEffect.Glow1: return "Balle lumineuse"; break;
				case SortNubiaEffect.Glow2: return "Balle lumineuse déformée"; break;
				case SortNubiaEffect.Glow3: return "Etoile"; break;
				case SortNubiaEffect.Visage: return "Visage"; break;

				case SortNubiaEffect.SmallFireBall: return "Trait de feu"; break;
				case SortNubiaEffect.Smoke: return "Fumée"; break;
				case SortNubiaEffect.DoubleHead: return "Double-tête tournantes"; break;
				case SortNubiaEffect.Rock: return "Rock"; break;
				case SortNubiaEffect.Crane: return "Crane"; break;
				case SortNubiaEffect.Trait: return "Trait/Aiguille"; break;
			}
			return "Inconnu";
		}
		public static string GetDisturbMessage(MagieDisturb dis)
		{
			switch(dis)
			{
				case MagieDisturb.SortNubia: return "Interruption de votre SortNubia";break;
                case MagieDisturb.Mort: return ""; break;
                case MagieDisturb.Mouvement: return "Vous perdez votre concentration"; break;
                case MagieDisturb.Mana: return "Vous n'avez plus assez de chakra"; break;
			}
			return "Interruption pour cause inconnu";
		}

		public static void MakeParalyzeEffect(NubiaPlayer caster, Mobile cible, SortEnergie type, double time)
		{
			int effet =	0xD26;
			if(type == SortEnergie.Vie)
			{
				switch(Utility.RandomMinMax(0,3))
				{
					case 0: effet = 3378; break;
					case 1: effet = 3379; break;
					case 2: effet = 3391; break;
					case 3: effet = 3392; break;
				}
			}
            if (type == SortEnergie.Terre)
			{
				switch(Utility.RandomMinMax(0,3))
				{
					case 0: effet = 6001; break;
					case 1: effet = 6002; break;
					case 2: effet = 6005; break;
					case 3: effet = 6005; break;
				}
			}
            if (type == SortEnergie.Terre)
			{
				switch(Utility.RandomMinMax(0,3))
				{
					case 0: effet = 12252; break;
					case 1: effet = 12253; break;
					case 2: effet = 12262; break;
					case 3: effet = 12263; break;
				}
			}
            if (type == SortEnergie.Terre)
			{ 
				effet = 13597;
			}
			cible.FixedParticles( effet, (int)(time*20), 32, 5030, -1, (int)MagieRender.Normal, EffectLayer.Waist );
		}

		public static void MakeEffect(NubiaPlayer caster, Mobile cible, SortNubia SortNubia, bool move, bool explose)
		{
			//COULEUR
			int color = 0;
			int render = (int)SortNubia.render;
			switch(SortNubia.couleur)
			{
				case MagieColor.Chakra: color = caster.ChakraColor; break;
               // case MagieColor.Connaissance: color = KonohaCompHelper.getCompColor(SortNubia.competence); Console.WriteLine("Connaissance dans MakeEffect:" + SortNubia.competence.ToString()); break;
			}

			int effet = 0x36D4;
			int exploseEffet = 4019;
			int sound = 0x15E;
			

			switch(Utility.RandomMinMax(0,2))
			{
				case 0: exploseEffet = 0x36B0; break;
				case 1: exploseEffet = 0x36BD; break;
				case 2:	exploseEffet = 0x36CA; break;
			}

			switch(SortNubia.effect)
			{
				case SortNubiaEffect.Bee: effet = 0x923; break;
				case SortNubiaEffect.BladeSpirit: effet = 0x37EB; break;
				case SortNubiaEffect.BlueSparkle: effet = 0x373A; break;
				case SortNubiaEffect.BlueGoldSparkle1: effet = 0x375A; break;
				case SortNubiaEffect.BlueGoldSparkle2: effet = 0x376A; break;
				case SortNubiaEffect.BluePurpleSparkle: effet = 0x3779; break;
				case SortNubiaEffect.RedSparkle: effet = 0x374A; break;
				case SortNubiaEffect.Energy: effet = 0x3819; break;
				case SortNubiaEffect.Vortex: effet = 0x3789; break;
				case SortNubiaEffect.ExplosionBall: effet = 0x36FE; break;
				case SortNubiaEffect.FireSnake: effet = 0x36F4; break;
				case SortNubiaEffect.Glow1: effet = 0x37B9; break;
				case SortNubiaEffect.Glow2: effet = 0x37BE; break;
				case SortNubiaEffect.Glow3: effet = 0x37C4; break;
				case SortNubiaEffect.Visage: effet = 0x1ED9; break;
				case SortNubiaEffect.SmallFireBall: effet = 0x36E4; break;
				case SortNubiaEffect.Smoke: effet = 0x3728; break;
				case SortNubiaEffect.DoubleHead: effet = 0x1F1F; break;
				case SortNubiaEffect.Rock: effet = Utility.RandomMinMax(0x1363,0x123D); break;
				case SortNubiaEffect.Crane: effet = 0x1456; break;
				case SortNubiaEffect.Trait: effet = 0x1BFE; break;
			}
			
			if(move)
				caster.MovingParticles( cible, effet, 7, 0, false, explose, color-1, render, 9502, exploseEffet, 0x160,0 );
			else //( int itemID, int speed, int duration, int effect, int hue, int renderMode, EffectLayer layer )
				cible.FixedParticles( effet, 9, 32, 5030, color-1, render, EffectLayer.Waist );
			cible.PlaySound( sound );
		}
	}
}