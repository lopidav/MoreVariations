
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationWide : CardVariationData
{
    static string VariationId = "wide";
    public override void OnAddingToCard(GameCard card)
    {
        //if (card.IsEquipped && card.BeingDragged) return;
        card.startScale.x *= 2f;
        base.OnAddingToCard(card);
    }
    public override void OnCardStart(GameCard card)
    {
        //if (card.IsEquipped && card.BeingDragged) return;
        card.startScale.x *= 2f;
        base.OnCardStart(card);
    }

	public override string ToString()
	{
		return $"{VariationId}";
	}
}