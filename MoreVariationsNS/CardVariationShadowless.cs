
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationShadowless : CardVariationData
{
    static string VariationId = "shadowless";
    public override void OnPostUpdate(GameCard card)
    {
        card.CardRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        //if (card.CardData != null && card.CardData.nameOverride != " ") card.CardData.nameOverride = " ";
    }

	public override string ToString()
	{
		return $"{VariationId}";
	}
}