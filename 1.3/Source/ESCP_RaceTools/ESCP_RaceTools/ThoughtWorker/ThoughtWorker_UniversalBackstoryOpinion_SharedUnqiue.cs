﻿using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace ESCP_RaceTools
{
    class ThoughtWorker_UniversalBackstoryOpinion_SharedUnqiue : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
        {
            if (ModSettingsUtility.ESCP_RaceTools_EnableBackstoryOpinions())
            {
                if (pawn.story.adulthood == null || other.story.adulthood == null)
                {
                    return false;
                }
                var props = ThoughtDefProperties.Get(this.def);
                if (props != null && props.sharedBackstoryCategories != null)
                {
                    Backstory a = pawn.story.adulthood;
                    Backstory b = other.story.adulthood;
                    foreach (string str in props.sharedBackstoryCategories)
                    {
                        if (a.spawnCategories.Contains(str))
                        {
                            foreach(string strb in props.sharedBackstoryCategories)
                            {
                                if (b.spawnCategories.Contains(strb) && strb != str)
                                {
                                    return ThoughtState.ActiveAtStage(0);
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
