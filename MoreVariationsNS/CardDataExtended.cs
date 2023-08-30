using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MoreVariationsNS;
public static class CardDataExtended
{
    private static readonly ConditionalWeakTable<CardData, StrongBox<List<CardVariationData>>> _Variations_f = new ConditionalWeakTable<CardData, StrongBox<List<CardVariationData>>>();
    public static bool IsVariation(this CardData card, string variationId = "")
    {
        StrongBox<List<CardVariationData>> box;
        if (!_Variations_f.TryGetValue(card, out box))
        {
            return false;
        }
        if (variationId == "") return box.Value != null && box.Value.Count > 0;

        List<CardVariationData> variationList = box.Value;
        return variationList.Find(CardVariationData => CardVariationData.VariationId == variationId) != null;
    }
    public static CardVariationData GetVariationCardVariationData(this CardData card, string variationId)
    {
        StrongBox<List<CardVariationData>> box;
        if (!_Variations_f.TryGetValue(card, out box))
        {
            return null;
        }
        return box.Value.Find(CardVariationData => CardVariationData.VariationId == variationId);
    }
    public static List<CardVariationData> GetVariationList(this CardData card)
    {
        StrongBox<List<CardVariationData>> box;
        if (!_Variations_f.TryGetValue(card, out box))
        {
            return new List<CardVariationData>();
        }
        return box.Value ?? new List<CardVariationData>();
    }
    /*public static object GetVariationData(this CardData card, string variationId)
    {
        StrongBox<List<CardVariationData>> box;
        if (!_Variations_f.TryGetValue(card, out box))
        {
            return null;
        }
        CardVariationData data = box.Value.Find(CardVariationData => CardVariationData.AttributeId == variationId);
        return GetExtraDataValue(data);
    }*/
    /*public static object GetExtraDataValue(CardVariationData data)
    {
        if (data == null) return null;
        //MoreVariationsPlugin.Log(data.ToString());

        if (data.VectorValue != new Vector3(0f,0f,0f)) return data.VectorValue;
        if (!string.IsNullOrEmpty(data.StringValue)) return data.StringValue;
        if (data.FloatValue != 0f) return data.FloatValue;
        if (data.IntValue != 0) return data.IntValue;
        if (data.BoolValue) return data.BoolValue;
        return false;
    }*/
    public static List<CardVariationData> AddVariationData(this CardData card, CardVariationData variation)
    {
        if (variation == null) return null;

        StrongBox<List<CardVariationData>> box;
        box = _Variations_f.GetOrCreateValue(card);
        if (box.Value == null) box.Value = new List<CardVariationData>();
        box.Value.Add(variation);
        variation.OnAddingToCard(card.MyGameCard);
        return box.Value;
    }
    /*public static void SetExtraDataData(CardVariationData data, object setting)
    {
        if (data == null) return;
        if (setting == null) return;
        if (setting is Vector3 vector)
        {
            data.VectorValue = vector;
            return;
        }
        if (setting is string str)
        {
            data.StringValue = str;
            return;
        }
        if (setting is float fl)
        {
            data.FloatValue = fl;
            return;
        }
        if (setting is int integer)
        {
            data.IntValue = integer;
            return;
        }
        if (setting is bool boolean)
        {
            data.BoolValue = boolean;
            return;
        }
        return;
    }*/
    /*
    public static CardVariationData NewVariationDataWithData(string AttributeId, object setting)
    {
        if (setting == null) return new CardVariationData(AttributeId, false);
        if (setting is Vector3 vector) return new CardVariationData(AttributeId, vector);
        if (setting is string str) return new CardVariationData(AttributeId, str);
        if (setting is float fl) return new CardVariationData(AttributeId, fl);
        if (setting is int integer) return new CardVariationData(AttributeId, integer);
        if (setting is bool boolean) return new CardVariationData(AttributeId, boolean);
        return new CardVariationData(AttributeId, false);
    }*/
    

}