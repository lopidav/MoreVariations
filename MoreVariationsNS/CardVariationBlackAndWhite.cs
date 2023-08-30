
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationBlackAndWhite : CardVariationData
{
    static string VariationId = "black and white";
    public override void OnPostUpdate(GameCard card)
    {
        if (card.CardData == null) return; 
		MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
		Color White = Color.white.RGBMultiplied(0.95f);
		Color Black = Color.black;
		if (card.IsHit)
		{
			White = Color.white;
			Black = Color.white;
		}
		card.CombatStatusCircle.color = White;
		card.CardRenderer.GetPropertyBlock(propBlock, 2);
		propBlock.SetFloat("_HasSecondaryIcon", 0f);
		propBlock.SetColor("_Color", White);
		propBlock.SetColor("_Color2", White);
		propBlock.SetColor("_IconColor", Black);
		card.CardRenderer.SetPropertyBlock(propBlock, 2);
		card.SpecialText.color = White;
		card.SpecialIcon.color = Black;
		card.IconRenderer.color = White;
		card.CoinText.color = White;
		card.CoinIcon.color = Black;
		card.EquipmentButton.Color = White;
		card.CardNameText.color = Black;
    }

	public override string ToString()
	{
		return $"{VariationId}";
	}
}