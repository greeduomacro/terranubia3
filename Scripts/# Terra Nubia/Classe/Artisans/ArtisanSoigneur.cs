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

        public override DonEnum[][] DonClasse
        {
            get
            {
                return new DonEnum[][]{
                    new DonEnum[0], //0
                    new DonEnum[]{DonEnum.DonSupClasse}, // 1
                    new DonEnum[0], //2
                    new DonEnum[]{DonEnum.DonSupClasse}, //3
                     new DonEnum[0], //4
                    new DonEnum[]{DonEnum.DonSupClasse}, //5
                  
                };
            }
        }

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