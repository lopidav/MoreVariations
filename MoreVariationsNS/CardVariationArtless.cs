
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationArtless : CardVariationData
{
    static string VariationId = "artless";
    public override void OnPostUpdate(GameCard card)
    {
        if (card.CardData != null && card.CardData.Icon != null) card.CardData.Icon = null;
        if (card.IconRenderer.sprite != null) card.IconRenderer.sprite = null;
		if ((card?.CardData is ResourceChest chest && chest.HeldCardId != "")
            || (card?.CardData is ResourceMagnet magnet && magnet.PullCardId != ""))
		{
            MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
	        card.CardRenderer.GetPropertyBlock(propBlock, 2);
		    propBlock.SetFloat("_HasSecondaryIcon", 0f);
		    propBlock.SetTexture("_IconTex", SpriteManager.instance.EmptyTexture.texture);
	        card.CardRenderer.SetPropertyBlock(propBlock, 2);
		}
    }

	public override string ToString()
	{
		return $"{VariationId}";
	}
}