
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationWhiteBorder : CardVariationData
{
    static string VariationId = "white border";
    public override void OnPostUpdate(GameCard card)
    {
	    card.CardRenderer.GetPropertyBlock(card.propBlock, 2);
	    card.propBlock.SetColor("_BorderColor", Color.white);
	    card.CardRenderer.SetPropertyBlock(card.propBlock, 2);
        base.OnPostUpdate(card);
    }
    public override void OnAddingToCard(GameCard card)
    {
        Material cardFrontMaterial = card.CardRenderer.materials.First(mat => mat.name == "CardFront (Instance)");
        if (cardFrontMaterial)
        {
            MoreVariationsPlugin.Log("eyyyyy");
            cardFrontMaterial.shader = MoreVariationsPlugin.customCardShader;
            cardFrontMaterial.SetFloat("_Glossiness", -2f);
            cardFrontMaterial.SetFloat("_Metallic", -0.2f);
        }
        else
        {
            MoreVariationsPlugin.Log("ooooooh nnoooooooo");
        }

        base.OnAddingToCard(card);
    }
	public override string ToString()
	{
		return $"{VariationId}";
	}
}