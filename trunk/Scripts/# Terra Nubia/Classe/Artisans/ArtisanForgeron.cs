using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ArtisanForgeron : ClasseArtisan
    {
        public ArtisanForgeron() { }

        public override ClasseType CType { get { return ClasseType.ArtisanForgeron; } }

        public override CompType[] ClasseCompetences
        {
            get
            {
                return new CompType[]{
                     CompType.Forge
                };
            }
        }
        public override CompType[] CompToLearn
        {
            get
            {
                return new CompType[] { CompType.Minage };
            }
        }

    }
}