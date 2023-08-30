
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationStanding : CardVariationData
{
    static string VariationId = "standing";
    public override void OnPostUpdate(GameCard card)
    {
        if (card.IsEquipped && card.BeingDragged) return;
        Vector3 newPosition = card.transform.localPosition;
        newPosition.y += 0.1f;
        card.transform.localRotation *= Quaternion.Euler(-65f, 0f, 0f);
        card.transform.localPosition = newPosition;
        base.OnPostUpdate(card);
    }

	public override string ToString()
	{
		return $"{VariationId}";
	}
}