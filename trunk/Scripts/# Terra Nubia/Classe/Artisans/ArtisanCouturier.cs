using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ArtisanCouturier : ClasseArtisan
    {
        public ArtisanCouturier() { }

        public override ClasseType CType { get { return ClasseType.ArtisanCouturier; } }

         public override CompType[] ClasseCompetences
         {
             get
             {
                 return new CompType[]{
                     CompType.Couture
                };
             }
         }
         public override CompType[] CompToLearn
         {
             get
             {
                 return new CompType[]{ CompType.Agriculture  };
             }
         }

    }
}