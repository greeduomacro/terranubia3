using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ArtisanEbeniste : ClasseArtisan
    {
        public ArtisanEbeniste() { }

        public override ClasseType CType { get { return ClasseType.ArtisanEbeniste; } }

        public override CompType[] ClasseCompetences
        {
            get
            {
                return new CompType[]{
                     CompType.Ebenisterie
                };
            }
        }
        public override CompType[] CompToLearn
        {
            get
            {
                return new CompType[] { CompType.Buchage };
            }
        }

    }
}