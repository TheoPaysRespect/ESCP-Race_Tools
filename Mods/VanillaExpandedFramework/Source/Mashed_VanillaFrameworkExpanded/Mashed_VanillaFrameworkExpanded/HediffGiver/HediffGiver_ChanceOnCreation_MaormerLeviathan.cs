﻿using System;
using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using Verse;
using ESCP_RaceTools;
using VFECore.Abilities;

namespace Mashed_VanillaFrameworkExpanded
{
    class HediffGiver_ChanceOnCreation_MaormerLeviathan : HediffGiver
    {
        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            if (!HasHediff(pawn))
            {
                if (Rand.Chance(ModSettingsUtility_Race.ESCP_RaceTools_MaormerLeviathanChance()))
                {
                    pawn.health.AddHediff(this.hediff).Severity = activatedSeverity;
                    pawn.GetComp<VFECore.Abilities.CompAbilities>()?.GiveAbility(abilityDef);
                }
                else
                {
                    pawn.health.AddHediff(this.hediff).Severity = inactiveSeverity;

                }

            }
        }

        public bool HasHediff(Pawn pawn)
        {
            return pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff) != null;
        }

        public float inactiveSeverity = 0.5f;
        public float activatedSeverity = 1f;
        public VFECore.Abilities.AbilityDef abilityDef;
        //bool random pick
        //int number to pick
        //list abilities
    }
}
