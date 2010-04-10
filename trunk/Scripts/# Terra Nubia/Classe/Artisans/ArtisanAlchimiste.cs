using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ArtisanAlchimiste : ClasseArtisan
    {
        public ArtisanAlchimiste() { }

        public override ClasseType CType { get { return ClasseType.ArtisanAlchimiste; } }

        public override CompType[] ClasseCompetences
        {
            get
            {
                return new CompType[]{
                     CompType.Chimie
                };
            }
        }
        public override CompType[] CompToLearn
        {
            get
            {
                return new CompType[] { CompType.Agriculture };
            }
        }

    }
}