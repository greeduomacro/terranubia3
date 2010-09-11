using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Factions;
using Server.Engines.Craft;
using System.Collections.Generic;
using Server.Misc;

namespace Server.Items
{
    public class NubiaWeapon : Item, INubiaCraftable,  IWeapon
    {
        public static string getTemplateString(ArmeTemplate t)
        {
            switch (t)
            {
                case ArmeTemplate.Arbalete: return "Arbalères";
                case ArmeTemplate.Arc: return "Arcs";
                case ArmeTemplate.Baton: return "Batons";
                case ArmeTemplate.Dague: return "Dagues";
                case ArmeTemplate.Epee: return "Epées";
                case ArmeTemplate.Hache: return "Haches";
                case ArmeTemplate.Hast: return "Armes d'Hast";
                case ArmeTemplate.Lance: return "Lances";
                case ArmeTemplate.Masse: return "Masses";
                case ArmeTemplate.Poing: return "Poings";
                case ArmeTemplate.Jet: return "Armes de jet";
            }
            return "none";
        }

        private De mDe = De.trois;
        private int mNbrLance = 1;
        private int mMiniCritique = 20; // mMiniCritique ou supérieur sur 1d20 pour un coup critique
        private int mCritiqueMulti = 2;
        private int mMaxRange = 1;
        private int mBonusDegatStatic = 0;
        private ArmeCategorie mArmeCategorie = ArmeCategorie.Courante;
        private ArmeTemplate mTemplate = ArmeTemplate.Arbalete;

        [CommandProperty(AccessLevel.GameMaster)]
        public int BonusDegatStatic
        {
            get { return mBonusDegatStatic; }
            set { mBonusDegatStatic = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public ArmeCategorie ArmeCategorie
        {
            get { return mArmeCategorie; }
            set { mArmeCategorie = value; }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxRange
        {
            get { return mMaxRange; }
            set { mMaxRange = value; }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public De De
        {
            get { return mDe; }
            set { mDe = value; }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int NbrLance
        {
            get { return mNbrLance; }
            set { mNbrLance = value; }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int MiniForCritique
        {
            get { return mMiniCritique; }
            set { mMiniCritique = value; }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int CritiqueMulti
        {
            get { return mCritiqueMulti; }
            set { mCritiqueMulti = value; }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public virtual int DefHitSound { get { return 0; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public virtual int DefMissSound { get { return 0; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual WeaponAnimation DefAnimation { get { return WeaponAnimation.Wrestle; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual ArmeTemplate Template { get { return mTemplate; } }


        private bool mOpportunite = false; // en cas d'attaque d'opportunité, on divise par deux le délai entre deux attaque

        #region Craft Variable & Functions
        private int mHitsMax = 50;
        private int mHits = 50;
        private int mBonusAttaque = 0;
        private int mBonusDegat = 0;
        private Mobile mArtisan = null;
        private NubiaQualityEnum mNubiaQuality = NubiaQualityEnum.Mauvaise;
        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Artisan { get { return mArtisan; } set { mArtisan = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaQualityEnum NQuality { get { return mNubiaQuality; } set { AfterCraft(value); } }

        private List<NubiaRessource> mTRessourceList = new List<NubiaRessource>();
        public List<NubiaRessource> TRessourceList { get { return mTRessourceList; } }

        public void AfterCraft(NubiaQualityEnum quality)
        {
            mNubiaQuality = quality;
            for (int i = 0; i < mTRessourceList.Count; i++)
            {
                NubiaRessource res = mTRessourceList[i];
                NubiaInfoRessource infos =
                    NubiaInfoRessource.GetInfoRessource(res);
                mBonusAttaque = Math.Max(mBonusAttaque, infos.BonusAttaque);
                mBonusDegat = Math.Max(mBonusDegat, infos.BonusDegat);
                mHitsMax = Math.Max((int)(50.0 * infos.Durabilite), mHitsMax);
                mHits = mHitsMax;
            }
            switch (mNubiaQuality)
            {
                case NubiaQualityEnum.Mauvaise: mBonusAttaque--; break;
                case NubiaQualityEnum.Bonne: mHitsMax += 10; break;
                case NubiaQualityEnum.Excellente: mBonusAttaque++; mHitsMax += 20; break;
                case NubiaQualityEnum.Maitre: mBonusAttaque++; mBonusDegat++; mHitsMax += 30; break;
                    
            }
        }

        #endregion


        public NubiaWeapon(ArmeTemplate template, int ItemId)
            : base(ItemId)
        {
            mTemplate = template;
            Layer = Layer.OneHanded;
            if (template == ArmeTemplate.Arbalete)
            {
                mDe = De.huit;
                mMiniCritique = 19;
                mMaxRange = 15;
                mArmeCategorie = ArmeCategorie.Exotique;
                Layer = Layer.TwoHanded;
            }
            else if (template == ArmeTemplate.Arc)
            {
                mDe = De.huit;
                mMiniCritique = 19;
                mMaxRange = 15;
                mArmeCategorie = ArmeCategorie.Guerre;
                Layer = Layer.TwoHanded;
            }
            else if (template == ArmeTemplate.Baton)
            {
                mDe = De.six;
                mMiniCritique = 20;
                Layer = Layer.TwoHanded;
            }
            else if (template == ArmeTemplate.Dague)
            {
                mDe = De.quatre;
                mMiniCritique = 19;                
            }
            else if (template == ArmeTemplate.Epee)
            {
                mDe = De.huit;
                mMiniCritique = 19;
                mArmeCategorie = ArmeCategorie.Guerre;
            }
            else if (template == ArmeTemplate.Hache)
            {
                mDe = De.dix;
                mMiniCritique = 20;
                mCritiqueMulti = 3;
                Layer = Layer.TwoHanded;
                mArmeCategorie = ArmeCategorie.Guerre;
            }
            else if (template == ArmeTemplate.Hast)
            {
                mDe = De.dix;
                mMiniCritique = 20;
                mCritiqueMulti = 3;
                mMaxRange = 2;
                Layer = Layer.TwoHanded;
                mArmeCategorie = ArmeCategorie.Guerre;
            }
            else if (template == ArmeTemplate.Lance)
            {
                mDe = De.huit;
                mMiniCritique = 20;
                mCritiqueMulti = 3;
                mMaxRange = 2;
                Layer = Layer.TwoHanded;
                mArmeCategorie = ArmeCategorie.Courante;
            }
            else if (template == ArmeTemplate.Masse)
            {
                mDe = De.huit;
                mMiniCritique = 20;
                mCritiqueMulti = 3;
                mMaxRange = 1;
                Layer = Layer.OneHanded;
                mArmeCategorie = ArmeCategorie.Guerre;
            }
            else if (template == ArmeTemplate.Jet)
            {
                mDe = De.huit;
                mMiniCritique = 19;
                mCritiqueMulti = 2;
                mMaxRange = 15;
                Layer = Layer.OneHanded;
                mArmeCategorie = ArmeCategorie.Guerre;
            }

            Weight = 10.0;
           // Name = "Nubia Weapon";
        }
        public NubiaWeapon(Serial serial) : base(serial) { }

        public override bool CheckConflictingLayer(Mobile m, Item item, Layer layer)
        {
            if (base.CheckConflictingLayer(m, item, layer))
                return true;

            if (this.Layer == Layer.TwoHanded && layer == Layer.OneHanded)
            {
                m.SendLocalizedMessage(500214); // You already have something in both hands.
                return true;
            }
            else if (this.Layer == Layer.OneHanded && layer == Layer.TwoHanded && !(item is BaseShield) && !(item is BaseEquipableLight))
            {
                m.SendLocalizedMessage(500215); // You can only wield one weapon at a time.
                return true;
            }

            return false;
        }

        public virtual void PlaySwingAnimation(Mobile from)
        {
            int action;

            switch (from.Body.Type)
            {
                case BodyType.Sea:
                case BodyType.Animal:
                    {
                        action = Utility.Random(5, 2);
                        break;
                    }
                case BodyType.Monster:
                    {
                        switch (DefAnimation)
                        {
                            default:
                            case WeaponAnimation.Wrestle:
                            case WeaponAnimation.Bash1H:
                            case WeaponAnimation.Pierce1H:
                            case WeaponAnimation.Slash1H:
                            case WeaponAnimation.Bash2H:
                            case WeaponAnimation.Pierce2H:
                            case WeaponAnimation.Slash2H: action = Utility.Random(4, 3); break;
                            case WeaponAnimation.ShootBow: return; // 7
                            case WeaponAnimation.ShootXBow: return; // 8
                        }

                        break;
                    }
                case BodyType.Human:
                    {
                        if (!from.Mounted)
                        {
                            action = (int)DefAnimation;
                        }
                        else
                        {
                            switch (DefAnimation)
                            {
                                default:
                                case WeaponAnimation.Wrestle:
                                case WeaponAnimation.Bash1H:
                                case WeaponAnimation.Pierce1H:
                                case WeaponAnimation.Slash1H: action = 26; break;
                                case WeaponAnimation.Bash2H:
                                case WeaponAnimation.Pierce2H:
                                case WeaponAnimation.Slash2H: action = 29; break;
                                case WeaponAnimation.ShootBow: action = 27; break;
                                case WeaponAnimation.ShootXBow: action = 28; break;
                            }
                        }

                        break;
                    }
                default: return;
            }

            from.Animate(action, 7, 1, true, false, 0);
        }

        public virtual TimeSpan OnSwing(Mobile attacker, Mobile defender)
        {
            return OnSwing(attacker, defender, 1.0);
        }

        public virtual TimeSpan OnSwing(Mobile attacker, Mobile defender, double damageBonus)
        {
            bool canSwing = true;

            if (attacker == null || defender == null)
                return WorldData.TimeTour();

            canSwing = (!attacker.Paralyzed && !attacker.Frozen);


            NubiaMobile AttMob = attacker as NubiaMobile;
            NubiaMobile DefMob = defender as NubiaMobile;

          
            //Bouclier total
            if (AttMob.GetActionCombat() == ActionCombat.DefenseTotale)
                canSwing = false;

           
            //Etourdi
            if (AttMob.IsEtourdi)
            {
                canSwing = false;
            }

            if (AttMob.IsRenverse && AttMob.Weapon is BaseRanged)
            {
                canSwing = false;
            }


            //Attaque à vue
            if (!NubiaHelper.LookAt(attacker, defender) && canSwing)
            {

                attacker.SendMessage("Vous devez êtres tourner vers {0} pour l'attaquer", defender.Name);
                PlaySwingAnimation(attacker);
                canSwing = false;
            }

            if (canSwing)
            {
                //Spell sp = attacker.Spell as Spell;

              //  canSwing = (sp == null || !sp.IsCasting || !sp.BlocksMovement);
            }

            if (canSwing && attacker.HarmfulCheck(defender))
            {
                attacker.DisruptiveAction();

                PlaySwingAnimation(attacker);

                if (attacker.NetState != null)
                    attacker.Send(new Swing(0, attacker, defender));

               /* if (attacker is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)attacker;
                    WeaponAbility ab = bc.GetWeaponAbility();

                    if (ab != null)
                    {
                        if (bc.WeaponAbilityChance > Utility.RandomDouble())
                            WeaponAbility.SetCurrentAbility(bc, ab);
                        else
                            WeaponAbility.ClearCurrentAbility(bc);
                    }
                }
            */

                CheckHit(attacker, defender);
                /* if (CheckHit(attacker, defender))
                     OnHit(attacker, defender);
                 else
                     OnMiss(attacker, defender);*/
            }

            return GetDelay(attacker);
        }

        public virtual bool CheckHit(Mobile attacker, Mobile defender)
        {

            /**
             * ANIMATION
             * PARER = 
             * ESQUIVER = 30 // 32 (se baisser)
             * COUP RECU = 20
             * TOMBER = 21
             * */
            NubiaMobile AttMob = attacker as NubiaMobile;
            NubiaMobile DefMob = defender as NubiaMobile;

            NubiaPlayer AttPlayer = null;
            if (attacker is NubiaPlayer)
                AttPlayer = attacker as NubiaPlayer;

            NubiaPlayer DefPlayer = null;
            if (defender is NubiaPlayer)
                DefPlayer = defender as NubiaPlayer;

            if (AttMob.getActionCombat() == ActionCombat.Renversement)
            {
                AttMob.NewActionCombat(ActionCombat.None);
                AttMob.ExposeToOpportunite();
                AttMob.Emote("*Tente un renversement*");
                int ddRenv = DndHelper.rollDe(De.vingt) + (int)Math.Max(DndHelper.GetCaracMod(DefMob, DndStat.Force), DndHelper.GetCaracMod(DefMob, DndStat.Dexterite));
                int rollAtt = DndHelper.rollDe(De.vingt) + (int)DndHelper.GetCaracMod(AttMob, DndStat.Force);
                if (AttPlayer != null && AttPlayer.hasDon(DonEnum.ScienceDuRenversement))
                    rollAtt += 4;
                if (rollAtt >= ddRenv)
                {
                    DefMob.doRenversement(1);
                }
                else
                {
                    AttMob.SendMessage("Vous ratez votre tentative");
                    DefMob.SendMessage("Vous resisté au renversement");
                    rollAtt = DndHelper.rollDe(De.vingt) + (int)Math.Max(DndHelper.GetCaracMod(AttMob, DndStat.Force), DndHelper.GetCaracMod(AttMob, DndStat.Dexterite));
                    ddRenv = DndHelper.rollDe(De.vingt) + (int)DndHelper.GetCaracMod(DefMob, DndStat.Force);
                    if (ddRenv > rollAtt)
                    {
                        if( !( AttPlayer != null && AttPlayer.hasDon(DonEnum.ScienceDuRenversement) ) )
                        {
                            AttMob.doRenversement(1);
                        }
                    }
                }
            }
            double DD = 0;
            //Attaque d'opportunité
            if (mOpportunite)
            {
                mOpportunite = false;
                string msg = "Attaque d'opportunité!";
                if (AttPlayer != null)
                    if (AttPlayer.hasDon(DonEnum.AttaqueSournoise))
                        msg = "Attaque sournoise!";

                if( DefPlayer != null && DefPlayer.hasDon(DonEnum.SouplesseDuSerpent ) )
                    DD += 4;

                AttMob.PrivateOverheadMessage(MessageType.Regular, 2119, false, msg, AttMob.NetState);
                AttMob.PrivateOverheadMessage(MessageType.Regular, 2119, false, msg, DefMob.NetState);
            }

            int roll = Utility.RandomMinMax(1, 20); //Jet de base du 1d20


            int minCritique = mMiniCritique;
            if (AttPlayer != null)
            {
                if (mTemplate == ArmeTemplate.Arbalete && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueArbalete))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Arc && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueArc))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Baton && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueBaton))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Dague && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueDague))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Epee && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueEpee))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Hache && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueHache))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Hast && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueHast))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Jet && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueJet))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Lance && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueLance))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Masse && AttPlayer.hasDon(DonEnum.ScienceDuCritiqueMasse))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
                else if (mTemplate == ArmeTemplate.Poing && AttPlayer.hasDon(DonEnum.ScienceDuCritiquePoing))
                    minCritique = 20 - ((20 - mMiniCritique) * 2);
            }
            bool coupCritique = (roll >= minCritique);

            double bonii = 0;

            //Bonus d'attaque du perso            
            bonii += AttMob.BonusAttaque[AttMob.GetAttackTurn()]; //On chope le bon bonus de classe(s) suivant le tour d'attaque 
            AttMob.DoAttackTurn();//Hop, un tour d'attaque pour passer au bonus suivant
           if (AttMob.AttaqueParTour > 1 && AttMob.Stam > 5)
           {               
               AttMob.Stam -= 4;
               if (AttPlayer != null)
               {
                   if (AttPlayer.DelugeDeCoup)
                       AttPlayer.Stam -= 1;
               }
           }
           else if (AttMob.AttaqueParTour > 1 && AttMob.Stam <= 5)
           {
               AttMob.AttaqueParTour = 1;
               if (AttPlayer != null)
                   AttPlayer.DelugeDeCoup = false;
               AttMob.SendMessage("Vous êtes trop fatigué pour maintenir l'attaque a outrance");
           }

            //Modificateur de charactéristique en fonction de l'arme Distance ou contact

           bool moineSag = false;
           bool attaqueFinesse = false;
           if (AttPlayer != null)
           {
               if (AttPlayer.hasClasse(ClasseType.Moine) && this is Fists)
               {
                   bonii += (double)DndHelper.GetCaracMod(AttPlayer, DndStat.Sagesse);
                   moineSag = true;
               }

               if (AttPlayer.hasDon(DonEnum.AttaqueEnFinesse) && AttPlayer.getBouclier() == null && (mTemplate == ArmeTemplate.Epee || mTemplate == ArmeTemplate.Dague || mTemplate == ArmeTemplate.Poing))
               {
                   bonii += (double)DndHelper.GetCaracMod(AttPlayer, DndStat.Dexterite, true);
                   attaqueFinesse = true;
               }

               if (AttPlayer.getActionCombat() == ActionCombat.AttaqueEnPuissance)
                   bonii -= AttPlayer.BonusAttaque[0] / 2;
           }

            if ( this.MaxRange > 3 && !moineSag)
                bonii += (double)DndHelper.GetCaracMod(AttMob, DndStat.Dexterite);
            else if (!moineSag && !attaqueFinesse)
                bonii += (double)DndHelper.GetCaracMod(AttMob, DndStat.Force);

            
          //  Console.WriteLine(AttMob.Name + " :: Bonus d'attaque (Classe+Mod Carac): +" + bonii);

           
            //Malus quand on attaque en courant
            // ???

            //Malus de -2 a l'attaque quand on porte un pavois
            Item ibouc = AttMob.FindItemOnLayer(Layer.TwoHanded);
            if (ibouc != null && ibouc is NubiaShield)
            {
                NubiaShield bouclier = ibouc as NubiaShield;
                if (bouclier.BType == BouclierType.Pavois)
                    bonii -= 2;
                else if (bouclier.BType == BouclierType.GrandPavois)
                    bonii -= 4;
            }

            //Malus au combat contre adversaires multiples. -2 par adversaire supplémentaires
            int malusAd = 0;
            malusAd = (AttMob.Aggressed.Count + AttMob.Aggressors.Count - 1) * (-2);
            bonii -= malusAd;

            //Malus / Bonus (Defense & Defense totale comprise)
            bonii += AttMob.getBonusRoll();

            /*
             *  MALUS/BONUS DES ARMES
             *  ---------------------
            */

            bonii += mBonusAttaque;

            //LANCE
            if (mTemplate == ArmeTemplate.Lance)
            {
                if (AttMob.InRange(DefMob.Location, 1))
                    bonii -= 6;
            } //POLEARMS
            else if (mTemplate == ArmeTemplate.Hast)
            {
                if (AttMob.InRange(DefMob.Location, 1))
                    bonii -= 7;
            } //MASSEs
            else if (mTemplate == ArmeTemplate.Masse)
            {
                bonii -= 6;
            }

           

            // Armes de prédilections
            if (AttPlayer != null)
            {
                if (mTemplate == ArmeTemplate.Arbalete && AttPlayer.hasDon(DonEnum.ArmeDePredilectionArbalete))
                    bonii ++;
                else if (mTemplate == ArmeTemplate.Arc && AttPlayer.hasDon(DonEnum.ArmeDePredilectionArc))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Baton && AttPlayer.hasDon(DonEnum.ArmeDePredilectionBaton))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Dague && AttPlayer.hasDon(DonEnum.ArmeDePredilectionDague))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Epee && AttPlayer.hasDon(DonEnum.ArmeDePredilectionEpee))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Hache && AttPlayer.hasDon(DonEnum.ArmeDePredilectionHache))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Hast && AttPlayer.hasDon(DonEnum.ArmeDePredilectionHast))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Jet && AttPlayer.hasDon(DonEnum.ArmeDePredilectionJet))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Lance && AttPlayer.hasDon(DonEnum.ArmeDePredilectionLance))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Masse && AttPlayer.hasDon(DonEnum.ArmeDePredilectionMasse))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Poing && AttPlayer.hasDon(DonEnum.ArmeDePredilectionPoing))
                    bonii++;

                if (mTemplate == ArmeTemplate.Arbalete && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupArbalete))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Arc && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupArc))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Baton && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupBaton))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Dague && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupDague))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Epee && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupEpee))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Hache && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupHache))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Hast && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupHast))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Jet && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupJet))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Lance && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupLance))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Masse && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupMasse))
                    bonii++;
                else if (mTemplate == ArmeTemplate.Poing && AttPlayer.hasDon(DonEnum.ArmeDePredilectionSupPoing))
                    bonii++;


                if (AttPlayer.Mount != null && !AttPlayer.hasDon(DonEnum.CombatMonte))
                    bonii -= 7;

                if (AttPlayer.getActionCombat() == ActionCombat.FeuNourri)
                {
                    if (AttPlayer.Weapon is BaseRanged)
                    {
                        bonii -= 4;
                        if (AttPlayer.BonusAttaque[0] >= 11)
                            bonii -= 2;
                        if (AttPlayer.BonusAttaque[0] >= 16)
                            bonii -= 2;

                    }
                }
            }

            //Renversé / A terre
            if (AttMob.IsRenverse)
            {
                bonii -= 4;
            }
            //Pris au dépourvu
            bool prisDepourvu = false;
            if ((AttMob.Hidden || !DefMob.Warmode) && !DefMob.InCombat)
            {
                bool esquive = false;
                if (DefPlayer != null)
                    esquive = DefPlayer.hasDon(DonEnum.EsquiveInstinctive);
                else
                    esquive = Utility.RandomDouble() < 0.05;
                if ( !esquive)
                {
                    prisDepourvu = true;
                    DefMob.Emote("*Prit au dépourvu*");

                }
                else
                {
                    DefMob.SendMessage("Votre don Esquive Instinctive vous évite d'être pris au dépourvu");
                }
            }

            DD += (DefMob.CA);
            if (prisDepourvu && DndHelper.GetCaracMod(DefMob, DndStat.Dexterite) > 0 )
                DD -= DndHelper.GetCaracMod(DefMob, DndStat.Dexterite);
            //Bonus avec un jet d'acrobatie réussi
            if (DefMob.getActionCombat() == ActionCombat.Defense 
                && DefMob.Competences[CompType.Acrobaties].getPureMaitrise() >= 5)
                DD += 1;
            else if (DefMob.getActionCombat() == ActionCombat.DefenseTotale 
                && DefMob.Competences[CompType.Acrobaties].getPureMaitrise() >= 5)
                DD += 2;
            else if (DefMob.Competences[CompType.Acrobaties].roll(15))
                DD += 1;

            if (DefMob.Mount != null)
                DD += 2;

            if (DefMob.IsEtourdi)
            {
                DD -= 2;
                DD -= DndHelper.GetCaracMod(DefMob, DndStat.Dexterite);
            }

            if (DefMob.IsRenverse)
            {
                if (AttMob.Weapon is BaseRanged)
                    DD += 4;
                else
                    DD -= 4;
            }
            //Test de bluff
            if (AttPlayer != null && AttMob.Competences[CompType.Bluff].getPureMaitrise() > 0)
            {
                if (AttPlayer.hasDon(DonEnum.ScienceDeLaFeinte))
                {
                    int bluffDD = DefMob.Competences[CompType.Psychologie].intRoll();
                    bluffDD += DefMob.BonusAttaque[DefMob.GetAttackTurn()];
                    if (DefMob.CreatureType != MobileType.Humanoide)
                        bluffDD += 4;
                    if (AttMob.Competences[CompType.Bluff].roll(bluffDD))
                    {
                        AttMob.Emote("*feinte*");
                        DD -= (DefMob.CA);
                    }
                }
            }

            if (DefMob is NubiaPlayer && DefMob.Weapon is NubiaWeapon)
            {
                int maitrise = ((NubiaPlayer)DefMob).getMaitrise( ((NubiaWeapon)DefMob.Weapon).Template );
                DD += maitrise/2.0;
            }

   

            double finalRoll = roll + bonii;

           // Console.WriteLine("{0} Frappe {1}. Jet d'attaque: {2}({4}+{5})(DD{3})", AttMob.Name, DefMob.Name, finalRoll.ToString(), DD.ToString(), roll.ToString(), bonii.ToString());

            //   attacker.SendMessage("{0}: Jet de {1}({2}) contre CA {3} de {4}", AttMob.Name, valMod, val, DefMob.CA, DefMob.Name);
            //  defender.SendMessage("{0}: Jet de {1}({2}) contre CA {3} de {4}", AttMob.Name, valMod, val, DefMob.CA, DefMob.Name);
            if ((finalRoll > DD || roll >= 20) && roll > 1)
            {

                //POLEARMS
                if (mTemplate == ArmeTemplate.Hast)
                {
                    //Attaque non voulue
                    if (Utility.Random(100) <= 5)
                    {
                        foreach (NubiaMobile mob in AttMob.GetMobilesInRange(2))
                        {
                            if (mob == AttMob || mob == DefMob)
                                continue;
                            if (NubiaHelper.LookAt(AttMob, mob))
                            {
                                AttMob.Emote("*Frappe par inadvertance {0}*", mob.Name);
                                DefMob = mob;
                                break;
                            }
                        }
                    }
                } //MASSEs
                else if ( mTemplate == ArmeTemplate.Masse)
                {
                    //Etourdir
                    if (Utility.Random(100) <= 5) //5% mais j'ai de force contre vigueur
                    {
                        AttMob.Emote("*Frappe violement {0}*", DefMob.Name);
                        bool result = DefMob.Etourdir(AttMob);
                        if (result)
                            DefMob.Emote("*Etourdit*");
                    }
                }
                



                double DamageBonus = 0.0;
                DamageBonus += DndHelper.GetCaracMod(AttMob, DndStat.Force); //Bonus du modificateur de Str aux dégats.

                // Bonus de dégat des buffs:
                DamageBonus += AttMob.getDegatBonus();

                if (Layer.TwoHanded == Layer && DamageBonus > 0)
                    DamageBonus *= 1.5;

             //   Console.WriteLine("Damage bonus après Carac & Arme 2M : " + DamageBonus.ToString());
            

                //Attaque d'opportunité
                if(  AttMob.getCanDoOpportunite() )
                    mOpportunite = DefMob.CheckForOpportuniteResult(AttMob) > 0;

                int damage = DndHelper.rollDe(this.mDe, this.mNbrLance);
                if (AttPlayer != null)
                {

                    if ( AttPlayer.hasClasse(ClasseType.Moine) && this is Fists)
                    {
                        
                        damage = ClasseMoine.getDamage(AttPlayer.getNiveauClasse(ClasseType.Moine));
                       // Console.WriteLine("Moine damage : "+damage.ToString() );
                    }
                  /*  else
                        damage = DndHelper.rollDe(this.mDe, this.mNbrLance);*/

                   
                }

                if (AttPlayer != null)
                {
                    if (mTemplate == ArmeTemplate.Arbalete && AttPlayer.hasDon(DonEnum.SpecialisationMartialeArbalete))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Arc && AttPlayer.hasDon(DonEnum.SpecialisationMartialeArc))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Baton && AttPlayer.hasDon(DonEnum.SpecialisationMartialeBaton))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Dague && AttPlayer.hasDon(DonEnum.SpecialisationMartialeDague))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Epee && AttPlayer.hasDon(DonEnum.SpecialisationMartialeEpee))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Hache && AttPlayer.hasDon(DonEnum.SpecialisationMartialeHache))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Hast && AttPlayer.hasDon(DonEnum.SpecialisationMartialeHast))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Jet && AttPlayer.hasDon(DonEnum.SpecialisationMartialeJet))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Lance && AttPlayer.hasDon(DonEnum.SpecialisationMartialeLance))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Masse && AttPlayer.hasDon(DonEnum.SpecialisationMartialeMasse))
                        DamageBonus += 2;
                    else if (mTemplate == ArmeTemplate.Poing && AttPlayer.hasDon(DonEnum.SpecialisationMartialePoing))
                        DamageBonus += 2;
                }

                damage += (int)DamageBonus + mBonusDegat;



                if (coupCritique) //Critique !
                {
                    
                    AttMob.PrivateOverheadMessage(MessageType.Regular, 2119, false, "Critique!", AttMob.NetState);
                  
                    //Poison des dagues
                  
                    damage *= mCritiqueMulti;

                    //BLESSURES
                    bool canBlessure = false;
                    if (AttPlayer != null)
                    {
                        canBlessure = !(AttPlayer.Weapon is Fists) || AttPlayer.hasDon(DonEnum.ScienceDuCombatAMainsNues);
                    }
                    else
                        canBlessure = true;
                    if (canBlessure)
                    {
                        double chance = 0.05;
                        if (AttPlayer != null && AttPlayer.hasDon(DonEnum.DurACuire))
                            chance -= 0.01;

                        if (AttMob.FindItemOnLayer(Layer.Helm) != null && AttMob.FindItemOnLayer(Layer.Helm) is NubiaArmor)
                        {
                            NubiaArmor helm = AttMob.FindItemOnLayer(Layer.Helm) as NubiaArmor;
                            chance -= 0.01;
                        }

                        if (Utility.RandomDouble() < chance)
                            DefMob.AddBlessure(NubiaBlessure.getRandomBlessure());
                    }
                }
                if (AttPlayer != null)
                {
                    if (AttPlayer.getActionCombat() == ActionCombat.AttaqueEnPuissance)
                    {
                        AttPlayer.NewActionCombat(ActionCombat.None);
                        AttPlayer.Emote("*Attaque en puissance*");
                        int damPuissance = AttPlayer.BonusAttaque[0];
                        if (!(Layer == Layer.TwoHanded) || mTemplate == ArmeTemplate.Poing)
                            damPuissance /= 2;
                        damage += damPuissance;
                        AttPlayer.Stam -= 10;
                    }

                    if (AttPlayer.getActionCombat() == ActionCombat.AttaqueEnRotation)
                    {
                        AttPlayer.NewActionCombat(ActionCombat.None);
                        AttPlayer.Emote("*attaque en rotation*");
                        AttPlayer.AttaqueParTour = 1;
                        AttPlayer.Stam -= 10;
                        IPooledEnumerable eable = AttPlayer.GetMobilesInRange(MaxRange);
                        foreach (Mobile m in eable)
                        {
                            if (m != DefMob)
                            {
                                m.Damage(damage, AttPlayer);
                            }
                        }
                        eable.Free();
                    }

                    if (AttPlayer.getActionCombat() == ActionCombat.CoupEtourdissant)
                    {
                        AttPlayer.NewActionCombat(ActionCombat.CoupEtourdissant);
                        int resistDD = 10 + (int)DndHelper.GetCaracMod(AttPlayer, DndStat.Sagesse) + (AttPlayer.Niveau / 2);
                        AttPlayer.Emote("*Coup étourdissant*");
                        if (resistDD > DndHelper.rollDe(De.vingt) + DefMob.getBonusVigueur())
                        {
                            DefMob.Etourdir();
                            DefMob.Emote("*Etourdit*");
                        }
                        else
                            DefMob.Emote("*Encaisse*");
                    }

                    if (AttPlayer.getActionCombat() == ActionCombat.FeuNourri)
                    {
                        AttPlayer.NewActionCombat(ActionCombat.None);
                        if (AttPlayer.Weapon is BaseRanged)
                        {
                            AttPlayer.Emote("*Feu nourri*");
                            int fleches = 1;
                            if (AttPlayer.BonusAttaque[0] >= 11)
                                fleches = 2;
                            if (AttPlayer.BonusAttaque[0] >= 16)
                                fleches = 3;
                            AttPlayer.Stam -= 10;
                            new FeuNourriTimer(fleches, this as BaseRanged, AttPlayer, DefMob).Start();
                        }
                    }

                   
                }
                //Attaque sournoise
                if (AttPlayer != null && mOpportunite)
                    if (AttPlayer.hasDon(DonEnum.AttaqueSournoise))
                    {
                        damage += DndHelper.rollDe(De.six, AttPlayer.getDonNiveau(DonEnum.AttaqueSournoise));
                    }


                if (DefPlayer != null)
                {
                    if ( this is BaseRanged && DefPlayer.hasDon(DonEnum.ParadeDeProjectiles) && DefPlayer.LastParadeProjectile + WorldData.TimeTour() < DateTime.Now)
                    {
                        DefPlayer.LastParadeProjectile = DateTime.Now;
                        damage = 0;
                        defender.Animate(20, 7, 1, true, false, 0);
                        if (DefPlayer.hasDon(DonEnum.InterceptionDeProjectile))
                        {
                            DefPlayer.Emote("*Attrape et renvoie le projectile*");
                            int defRenv = DefPlayer.BonusAttaque[DefPlayer.GetAttackTurn()] - 10 + (int)DndHelper.GetCaracMod(DefPlayer, DndStat.Dexterite);
                            if (defRenv > AttMob.CA)
                            {
                                int damRenv = DndHelper.rollDe(De.six) + (int)DndHelper.GetCaracMod(DefPlayer, DndStat.Force);
                                ((BaseRanged)this).OnHit(DefPlayer, AttMob, damRenv);
                            }
                            else
                                ((BaseRanged)this).OnMiss(DefPlayer, AttMob);
                        }
                        else
                        {
                            DefPlayer.Emote("*Pare le projectile*");
                            ((BaseRanged)this).OnMiss(AttMob, DefPlayer);
                        }
                    }
                }               
               

                OnHit(AttMob, DefMob, damage);
            }
            else
                OnMiss(AttMob, DefMob);
            
            return true;
        }

        private class FeuNourriTimer : Timer
        {
            private int mFleches = 0;
            private BaseRanged mWeapon = null;
            private NubiaMobile mAttacker = null;
            private NubiaMobile mDefender = null;
            public FeuNourriTimer(int fleches, BaseRanged weapon, NubiaMobile attacker, NubiaMobile defender)
                :base(TimeSpan.FromMilliseconds(500))
            {
                mFleches = fleches;
                mWeapon = weapon;
                mAttacker = attacker;
                mDefender = defender;
            }
            protected override void OnTick()
            {
                if (mWeapon != null && mAttacker !=  null && mDefender != null)
                {
                    if (mAttacker.Alive && mDefender.Alive)
                    {
                        mFleches--;
                        if (mWeapon.OnFired(mAttacker, mDefender))
                        {
                            mDefender.Damage(DndHelper.rollDe(mWeapon.De, mWeapon.NbrLance)
                                + (int)DndHelper.GetCaracMod(mAttacker, DndStat.Force)
                                , mAttacker);
                        }
                        if (mFleches > 0)
                            new FeuNourriTimer(mFleches, mWeapon, mAttacker, mDefender).Start();
                    }
                    Stop();
                }
            }
        }

        public virtual void OnHit(Mobile attacker, Mobile defender, double Damage)
        {
           // PlayHurtAnimation(defender);

            defender.Animate(20, 7, 1, true, false, 0);

            attacker.PlaySound(DefHitSound);
            defender.PlaySound(DefHitSound);

            NubiaMobile AttMob = attacker as NubiaMobile;
            NubiaMobile DefMob = defender as NubiaMobile;



            //XP
            if( attacker is NubiaPlayer )
                ((NubiaPlayer)attacker).GiveXP(10);

            if (DefMob.GetActionCombat() == ActionCombat.DefenseTotale)
                Damage /= 2;

            

            //Elite attaque
            if (attacker is NubiaCreature)
            {
                NubiaCreature creatAtt = attacker as NubiaCreature;
                if (creatAtt.IsElite)
                    Damage *= 1.5;
            }

            defender.Damage((int)Damage, attacker);
        }

        public virtual void OnMiss(Mobile attacker, Mobile defender)
        {
            NubiaMobile AttMob = attacker as NubiaMobile;
            NubiaMobile DefMob = defender as NubiaMobile;

            if (defender is NubiaPlayer)
                ((NubiaPlayer)defender).GiveXP(10);

            if (Utility.RandomDouble() > 0.1 || DndHelper.GetArmorCA(defender as NubiaMobile) < 2)
            {
                attacker.PlaySound(DefMissSound);
                defender.PlaySound(DefMissSound);
                defender.Animate((Utility.RandomDouble() > 0.9 ? 32 : 30), 7, 1, true, false, 0);
            }
            else
            {
                defender.FixedParticles(0x37B9, 1, 4, 0x251D, 0, 0, EffectLayer.Waist);
                attacker.PlaySound(DefHitSound);
                defender.PlaySound(DefHitSound);
                defender.Animate(20, 7, 1, true, false, 0);
            }
        }

        public virtual void OnBeforeSwing(Mobile attacker, Mobile defender)
        {
        }
        public virtual void GetStatusDamage(Mobile from, out int min, out int max)
        {
            min = 1;
            max = (int)mDe;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            // list.Add(String.Format("Rang: {0}\n",));
            string infos = "";

            infos += mTemplate.ToString() + "\n";
            if (Layer == Layer.TwoHanded)
                infos += "Arme à deux mains\n";

            if (mNubiaQuality != NubiaQualityEnum.Normale)
            {
                infos += NubiaQuality.getQualityName(mNubiaQuality) + "\n";
            }
            if (mTRessourceList.Count > 0)
            {
                for (int i = 0; i < mTRessourceList.Count; i++)
                {
                    infos += NubiaInfoRessource.GetInfoRessource(mTRessourceList[i]).Name;
                    if (i < mTRessourceList.Count - 1)
                        infos += ", ";
                }
                infos += "\n";
            }

            if (mBonusAttaque != 0)
                infos += "Attaque +" + mBonusAttaque +"\n";


            

            infos += String.Format("Catégorie: {0}\nDégats: {1}\nPortée: {2}m\nCritique: {3}",
                mArmeCategorie,
                DndHelper.nomDe(De, NbrLance) + (mBonusDegat>0? "+"+mBonusDegat.ToString(): ""),
                ((double)mMaxRange*1.5).ToString(),
                getStringCritique() );
            list.Add(infos);
        }
        public string getStringCritique(){
            string crit =  "";
            crit += mMiniCritique.ToString();
            if( mMiniCritique < 20 )
               crit += "-20";
            crit += "/'";
            crit += mCritiqueMulti.ToString();
            return crit;
            
        }

        public virtual TimeSpan GetDelay(Mobile m)
        {
            if (m == null)
                return WorldData.TimeTour();
            NubiaMobile mob = m as NubiaMobile;
            double baseSec = WorldData.TimeTour().Seconds;
            /*if (mob is NubiaPlayer)
            {
                int maitrise = ((NubiaPlayer)mob).getMaitrise(this.Template);
                if( maitrise > 3)
                    baseSec -= 0.1 * (maitrise - 3);
            }*/
            if (m is NubiaPlayer)
            {
                NubiaPlayer player = m as NubiaPlayer;
                if (player.hasDon(DonEnum.AttaquesReflexes) && mOpportunite)
                {
                    baseSec /= 2 + DndHelper.GetCaracMod(player, DndStat.Dexterite);
                }
                else if (mOpportunite)
                    baseSec /= 2;
            }
            else if (mOpportunite)
            {
                baseSec /= 2;
            }
            baseSec /= mob.AttaqueParTour;



            return TimeSpan.FromSeconds( baseSec - (Utility.RandomDouble())  );
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)2); //version
            writer.Write((int)mDe);
            writer.Write((int)mNbrLance);
            writer.Write((int)mMiniCritique);
            writer.Write((int)mCritiqueMulti);
            writer.Write((int)mMaxRange);
            writer.Write((int)mArmeCategorie);
            writer.Write((int)mTemplate);

            writer.Write((Mobile)mArtisan);

            writer.Write((int)mTRessourceList.Count);
            writer.Write((int)mNubiaQuality);
            for (int i = 0; i < mTRessourceList.Count; i++)
                writer.Write((int)mTRessourceList[i]);
            writer.Write((int)mBonusDegatStatic);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            mDe = (De)reader.ReadInt();
            mNbrLance = reader.ReadInt();
            mMiniCritique = reader.ReadInt();
            mCritiqueMulti = reader.ReadInt();
            mMaxRange = reader.ReadInt();
            mArmeCategorie = (ArmeCategorie)reader.ReadInt();
            mTemplate = (ArmeTemplate)reader.ReadInt();

            if (version >= 1)
            {
                mArtisan = reader.ReadMobile();

                int rescount = reader.ReadInt();
                mNubiaQuality = (NubiaQualityEnum)reader.ReadInt();
                mTRessourceList = new List<NubiaRessource>();
                for (int i = 0; i < rescount; i++)
                    mTRessourceList.Add((NubiaRessource)reader.ReadInt());

            }
            if (version >= 2)
            {
                mBonusDegatStatic = reader.ReadInt();
            }
        }
    }
}
