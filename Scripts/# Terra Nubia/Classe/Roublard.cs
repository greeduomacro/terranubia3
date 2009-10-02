using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ClasseRoublard : Classe
    {
        public override NubiaArmorType ArmorAllow { get { return NubiaArmorType.Legere; } }
        public override int GetDV { get { return 6; } }
        public override int PtComp { get { return 8; } }
        public ClasseRoublard() { }

        public override ClasseType CType { get { return ClasseType.Roublard; } }

        public override CompType[] ClasseCompetences
        {
            get
            {
                /* Acrobaties (Dex), Artisanat (Int), 
                 * Bluff (Cha), Connaissances (folklore local) (Int), 
                 * Contrefaçon (Int), Crochetage (Dex), 
                 * Décryptage (Int), Déguisement (Cha), 
                 * Déplacement silencieux (Dex), 
                 * Désamorçage/sabotage (Int), 
                 * Détection (Sag), Diplomatie (Cha), 
                 * Discrétion (Dex), Équilibre (Dex), 
                 * Escalade (For), Escamotage (Dex), 
                 * Estimation (Int), Évasion (Dex), 
                 * Fouille (Int), Intimidation (Cha), 
                 * Maîtrise des cordes (Dex), Natation (For), 
                 * Perception auditive (Sag), Profession (Sag), 
                 * Psychologie (Sag), Renseignements (Cha), 
                 * Représentation (Cha), Saut (For) 
                 * et Utilisation d’objets magiques (Cha).*/
                return new CompType[]{
                    CompType.Acrobaties,
                    CompType.Bluff,
                   // CompType.Contrefacon,
                    CompType.Crochetage,
               //     CompType.Decryptage,
                    CompType.Deguisement,
                    CompType.DeplacementSilencieux,
                    CompType.Desamorçage,
                    CompType.Detection,
                    CompType.Diplomatie,
                    CompType.Discretion,
                    CompType.Equilibre,
                    CompType.Escalade,
                    CompType.Escamotage,
                    CompType.Estimation,
                    CompType.Evasion,
                    CompType.Fouille,
                    CompType.Intimidation,
              //      CompType.MaitriseCordes,
                    CompType.PerceptionAuditive,
                    CompType.Psychologie,
                    CompType.Renseignements,
                    CompType.Representation,
                    CompType.Saut,
                    CompType.UtilisationObjetsMagiques
               };
            }
        }

        public override int[][] BonusAttaque
        {
            get
            {
                return new int[][] 
                { 
                    new int[] { 0 }, //0
                    new int[] { 0 }, //1
                    new int[] { 1 }, //2
                    new int[] { 2 }, //3
                    new int[] { 3 }, //4
                    new int[] { 3 }, //5
                    new int[] { 4 }, //6
                    new int[] { 5 }, //7
                    new int[] { 6,1 }, //8
                    new int[] { 6,1 }, //9
                    new int[] { 7,2 }, //10
                    new int[] { 8,3 }, //11
                    new int[] { 9,4 }, //12
                    new int[] { 9,4 }, //13
                    new int[] { 10,5 }, //14
                    new int[] { 11,6,1 }, //15
                    new int[] { 12,7,2 }, //16
                    new int[] { 12,7,2 }, //17
                    new int[] { 13,8,3 }, //18
                    new int[] { 14,9,4 }, //19
                    new int[] { 15,10,5 } //20
                };
            }
        }

        public override int[] BonusReflexe
        {
            get
            {
                return new int[]
                {
                    0, //0
                    2, //1
                    3, //2
                    3, //3
                    4, //4
                    4, //5
                    5, //6
                    5, //7
                    6, //8
                    6, //9
                    7, //10
                    7, //11
                    8, //12
                    8, //13
                    9, //14
                    9, //15
                    10, //16
                    10, //17
                    11, //18
                    11, //19
                    12, //20
                };
            }
        }

        public override int[] BonusVigueur
        {
            get
            {
                return new int[]
                {
                    0, //0
                    0, //1
                    0, //2
                    1, //3
                    1, //4
                    1, //5
                    2, //6
                    2, //7
                    2, //8
                    3, //9
                    3, //10
                    3, //11
                    4, //12
                    4, //13
                    4, //14
                    5, //15
                    5, //16
                    5, //17
                    6, //18
                    6, //19
                    6, //20
                };
            }
        }

        public override int[] BonusVolonte
        {
            get
            {
                return new int[]
                {
                    0, //0
                    0, //1
                    0, //2
                    1, //3
                    1, //4
                    1, //5
                    2, //6
                    2, //7
                    2, //8
                    3, //9
                    3, //10
                    3, //11
                    4, //12
                    4, //13
                    4, //14
                    5, //15
                    5, //16
                    5, //17
                    6, //18
                    6, //19
                    6, //20
                };
            }
        }
    }
}