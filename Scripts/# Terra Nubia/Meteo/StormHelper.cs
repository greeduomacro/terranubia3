using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Network;
using Server.Nubia;

namespace Server.Misc
{
	public static class StormHelper
	{
		public static void RandomFoudre( Rectangle2D area, Map map )
		{
			Point3D loc = new Point3D(0, 0, 0);;
			
			int x = Utility.RandomMinMax( area.X, area.X+area.Width );
			int y = Utility.RandomMinMax( area.Y, area.Y+area.Height );
			int z = map.GetAverageZ( x, y );
			
			loc = new Point3D(x, y, z);

			int nb = Utility.RandomMinMax(1,3);

			for( int i = 0; i < nb; i++)
			{
				BloodNubia caller = new BloodNubia();
				//caller.ItemID = 2277;
				caller.Hue = 1109;
				caller.Name = "Résidu de carbone";

				
				int xcaller = loc.X+Utility.RandomMinMax(-25,25);
				int ycaller = loc.Y+Utility.RandomMinMax(-25,25);
				caller.MoveToWorld( new Point3D( xcaller, ycaller , loc.Z), map );

				ImpactItem impact = new ImpactItem(false);
				impact.MoveToWorld( new Point3D( xcaller, ycaller, z+1), map );
				impact.Construct();
				//Console.WriteLine("Coordonnée de la foudre: ({0}, {1}, {2}) sur {3}", caller.X, caller.Y, caller.Z, map);
				

				Effects.SendBoltEffect( caller );
				caller.Delete();
			}
		}
	}
}