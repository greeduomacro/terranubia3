using System;
using System.Collections;
using Server;
using Server.Regions;

//new Point2D(2826,1360),new Point2D(2990,1530) (Chante Lune )
namespace Server.Regions
{
	public class ChanteLuneRegion : BaseNubiaRegion
	{
		public override bool CanFoudre { get{ return false; } }
		public override bool DisplayEnterExit { get{ return true; } }
		public ChanteLuneRegion() : base("Chante-Lune", 0, new Rectangle2D( new Point2D(2826,1360),new Point2D(2990,1530) ))
		{
		}
	}

	public class OmbreRocRegion : BaseNubiaRegion
	{
		public override bool CanFoudre { get{ return false; } }
		public override bool DisplayEnterExit { get{ return true; } }
		public OmbreRocRegion() : base("OmbreRoc", 0, new Rectangle2D( new Point2D(3577,1851),new Point2D(3748,1966) ))
		{
		}
	}

	
}