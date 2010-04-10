using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ArtisanPaysan : ClasseArtisan
    {
        public ArtisanPaysan() { }

        public override ClasseType CType { get { return ClasseType.ArtisanPaysan; } }

        public override CompType[] ClasseCompetences
        {
            get
            {
                return new CompType[]{
                     CompType.Agriculture, CompType.Brassage, CompType.Cuisine
                };
            }
        }
        public override CompType[] CompToLearn
        {
            get
            {
                return new CompType[] { CompType.Minage, CompType.Buchage };
            }
        }

    }
}