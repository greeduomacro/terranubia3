using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ArtisanSoigneur : ClasseArtisan
    {
        public ArtisanSoigneur() { }

        public override ClasseType CType { get { return ClasseType.ArtisanSoigneur; } }

        public override CompType[] ClasseCompetences
        {
            get
            {
                return new CompType[]{
                     CompType.Chirurgie,
                     CompType.PremiersSecours
                };
            }
        }
        public override CompType[] CompToLearn
        {
            get
            {
                return new CompType[] { CompType.Chimie };
            }
        }

    }
}