
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationTrembling : CardVariationData
{
    static string VariationId = "trembling";
    public override void OnPostUpdate(GameCard card)
    {
        if (card.IsEquipped && card.BeingDragged) return;
        Vector3 newPosition = card.transform.localPosition;
        newPosition.z += UnityEngine.Random.Range(-0.001f, 0.001f);
        newPosition.x += UnityEngine.Random.Range(-0.001f, 0.001f);
        card.transform.localRotation *= Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f, 1f));
        card.transform.localPosition = newPosition;
        base.OnPostUpdate(card);
    }

	public override string ToString()
	{
		return $"{VariationId}";
	}
}