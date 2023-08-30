
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationMirrored : CardVariationData
{
    static string VariationId = "mirrored";
    public override void OnPostUpdate(GameCard card)
    {
	    // card.CardRenderer.GetPropertyBlock(card.propBlock, 2);
	    // card.propBlock.SetFloat("_Mirrored", 1f);
	    // card.CardRenderer.SetPropertyBlock(card.propBlock, 2);
        base.OnPostUpdate(card);
    }
    public override void OnAddingToCard(GameCard card)
    {
        Vector3 scale = card.Visuals.localScale;
        scale.x *= -1f;
        card.Visuals.localScale = scale;

        base.OnAddingToCard(card);
    }
	public override string ToString()
	{
		return $"{VariationId}";
	}
}