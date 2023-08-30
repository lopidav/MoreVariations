
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationDescriptionless : CardVariationData
{
    static string VariationId = "descriptionless";
    public override void OnPostUpdate(GameCard card)
    {
        if (card.CardData != null && card.CardData.descriptionOverride != " ") card.CardData.descriptionOverride = " ";
        // if (card.CardNameText.text != "") card.CardNameText.text = "";
        // if (card.hove)
    }

	public override string ToString()
	{
		return $"{VariationId}";
	}
}