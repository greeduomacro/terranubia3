using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class RaceManager
    {
        public static Dictionary<RaceType, BaseRace> raceBank = new Dictionary<RaceType, BaseRace>();

        public static BaseRace getRace(RaceType race)
        {
            BaseRace raceClass = null;
            if (!raceBank.ContainsKey(race))
                createRace(race);
            if (raceBank.ContainsKey(race))
            {
                raceClass = raceBank[race];
            }
            return raceClass;
        }

        public static RaceType getRaceType(Type type)
        {
            if (type.Equals(typeof(RaceDemiElfe)))
                return RaceType.DemiElf;
            else if (type.Equals(typeof(RaceDemiOrc)))
                return RaceType.DemiOrc;
            else if (type.Equals(typeof(RaceElfeLune)))
                return RaceType.ElfLune;
            else if (type.Equals(typeof(RaceGithzerai)))
                return RaceType.Githzerai;
            else if (type.Equals(typeof(RaceHalfelin)))
                return RaceType.Halfelin;
            else if (type.Equals(typeof(RaceHumain)))
                return RaceType.Humain;

            else if (type.Equals(typeof(RaceHautElf)))
                return RaceType.HautElf;
            else if (type.Equals(typeof(RaceDrow)))
                return RaceType.Drow;
            else if (type.Equals(typeof(RaceDrake)))
                return RaceType.Drakeide;
            else if (type.Equals(typeof(RaceAasimar)))
                return RaceType.Aasimar;
            else if (type.Equals(typeof(RaceTiefelin)))
                return RaceType.Tiefelin;
            else if (type.Equals(typeof(RaceChangelin)))
                return RaceType.Changelin;

            return RaceType.None;
        }
        private static void createRace(RaceType race)
        {
            if ( !raceBank.ContainsKey(race))
            {
                switch (race)
                {
                    case RaceType.Aasimar: raceBank.Add(race, new RaceAasimar()); break;
                    case RaceType.Changelin: raceBank.Add(race, new RaceChangelin()); break;
                    case RaceType.DemiElf: raceBank.Add(race, new RaceDemiElfe()); break;
                    case RaceType.DemiOrc: raceBank.Add(race, new RaceDemiOrc()); break;
                    case RaceType.Drakeide: raceBank.Add(race, new RaceDrake()); break;
                    case RaceType.Drow: raceBank.Add(race, new RaceDrow()); break;
                    case RaceType.ElfLune: raceBank.Add(race, new RaceElfeLune()); break;
                    case RaceType.Githzerai: raceBank.Add(race, new RaceGithzerai()); break;
                    case RaceType.Halfelin: raceBank.Add(race, new RaceHalfelin());break;
                    case RaceType.HautElf: raceBank.Add(race, new RaceHautElf()); break;
                    case RaceType.Humain: raceBank.Add(race, new RaceHumain()); break;
                    case RaceType.Tiefelin: raceBank.Add(race, new RaceTiefelin()); break;
                }
            }
        }
    }
}
