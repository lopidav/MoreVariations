
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MoreVariationsNS;
[Serializable]
public class CardVariationData
{
	public string VariationId;
	public string StringValue;
	public float FloatValue;
	public Vector3 VectorValue;
	public bool BoolValue;

    public virtual void OnPostUpdate(GameCard card) {}
    public virtual void OnPreUpdate(GameCard card) {}
    public virtual void OnAddingToCard(GameCard card) {}
    public virtual void AddToCard(GameCard card) {}
    public virtual void RemoveFromCard(GameCard card) {}
    public virtual void OnCreationFromPack(GameCard card) {}
    public virtual void OnCardStart(GameCard card) {}
    public virtual CardVariationData GetCopy()
    {
        return (CardVariationData)this.MemberwiseClone();
    }
	
    public override string ToString()
	{
		return $"{VariationId} - {StringValue} - {FloatValue} - {BoolValue}";
	}
}