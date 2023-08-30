
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationTilted : CardVariationData
{
    static string VariationId = "tilted";
    public override void OnPostUpdate(GameCard card)
    {
        if (card.IsEquipped && card.BeingDragged) return;
        card.transform.localRotation *= Quaternion.Euler(0f, 0f, this.FloatValue);
        base.OnPostUpdate(card);
    }

	public override string ToString()
	{
		return $"{VariationId} {FloatValue}°";
	}
}