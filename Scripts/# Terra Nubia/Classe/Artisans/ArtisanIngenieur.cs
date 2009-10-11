using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ArtisanIngenieur : ClasseArtisan
    {
        public ArtisanIngenieur() { }

        public override ClasseType CType { get { return ClasseType.ArtisanIngenieur; } }

        public override CompType[] ClasseCompetences
        {
            get
            {
                return new CompType[]{
                     CompType.Ingenierie
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