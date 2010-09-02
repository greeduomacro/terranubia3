using System;
using System.Collections;
using Server;
using Server.Regions;
using Server.Items;
//new Point2D(2826,1360),new Point2D(2990,1530) (Chante Lune )
namespace Server.Regions
{
    public class RegionMineRendsbourg : BaseNubiaRegion
    {
        public override bool CanFoudre { get { return false; } }
        public override bool DisplayEnterExit { get { return true; } }
        public override bool CanAutoXP { get { return true; } }

        public override Server.Items.NubiaRessource[] Ressources
        {
            get
            {
                return new NubiaRessource[]{
                    NubiaRessource.Verdan,
                    NubiaRessource.Carriate,
                    NubiaRessource.Remiar,
                    NubiaRessource.Orafir,
                    NubiaRessource.Mythril,
                    NubiaRessource.Nafarite,
                    NubiaRessource.Revarium,
                    NubiaRessource.Trechar,
                    NubiaRessource.Floreas,
                    NubiaRessource.Oragite,
                    NubiaRessource.Lonaris,
                    NubiaRessource.Celiar,
                    NubiaRessource.Firatas,
                    NubiaRessource.Verate,
                    NubiaRessource.Drachior,
                    NubiaRessource.Glarias,
                    NubiaRessource.Nethar,
                    NubiaRessource.Divarium,
                    NubiaRessource.Palerias,
                    NubiaRessource.Nirior
                };
            }
        }

        public RegionMineRendsbourg()
            : base("Mine de Rendsbourg", 0,
                new Rectangle2D(new Point2D(1337, 1527), new Point2D(1266, 1491)),Map.Ilshenar)
        {
        }
    }


}