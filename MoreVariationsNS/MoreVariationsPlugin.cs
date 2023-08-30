using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace MoreVariationsNS;

[BepInPlugin("MoreVariations", "MoreVariations", "0.2.0")]
public class MoreVariationsPlugin : BaseUnityPlugin
{
	public static ManualLogSource L;
	public static void Log(string s)
	{
		L.LogInfo((object)(DateTime.Now.ToString("HH:MM:ss") + ": " + s));
	}

	public static Harmony HarmonyInstance;
	public void Awake()
	{
		L = ((MoreVariationsPlugin)this).Logger;

		try
		{
			HarmonyInstance = new Harmony("MoreVariationsPlugin");
			HarmonyInstance.PatchAll(typeof(MoreVariationsPlugin));
		}
		catch (Exception ex3)
		{
			Log("Patching failed: " + ex3.Message);
		}
	}
	private static AssetBundle assetBundle;
	public static Shader customCardShader;
	private void Start()
	{
		assetBundle = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Info.Location), "cardshaderbundle"));//LoadAssetBundle("MoreVariations.bundles");
        if (assetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
		customCardShader = assetBundle.LoadAsset<Shader>("CardShader");
		assetBundle.Unload(false);
	}
	public static AssetBundle LoadAssetBundle(string resourceName) {
		Assembly execAssembly = Assembly.GetExecutingAssembly();

		using (Stream stream = execAssembly.GetManifestResourceStream(resourceName)) {
			return AssetBundle.LoadFromStream(stream);
		}
	}

	[HarmonyPatch(typeof(GameCard), "Update")]
	[HarmonyPostfix]
	public static void GameCard_Update_Postfix(GameCard __instance)
	{
		if (__instance.CardData == null) return;
		foreach (CardVariationData variation in __instance.CardData.GetVariationList())
		{
			variation?.OnPostUpdate(__instance);
		}
	}
	[HarmonyPatch(typeof(CardData), "SetFoil")]
	[HarmonyPostfix]
	public static void CardData_SetFoil_Postfix(CardData __instance)
	{
		__instance.AddVariationData(new CardVariationBorderless());
	}
	[HarmonyPatch(typeof(CardData), "FullName", MethodType.Getter)]
	[HarmonyPostfix]
	public static void CardData_FullName_Getter_Postfix(ref string __result, CardData __instance)
	{
		if (!__instance.IsVariation()) return;
		if (__result.Last() == ')')
		{
			__result = __result.TrimEnd(')');
			__result += ", ";
		}
		else
		{
			__result += " (";
		}
		__result += __instance.GetVariationList().Join(data => data.ToString());
		__result += ")";
	}
	[HarmonyPatch(typeof(WorldManager), "CreateCard", new Type[]
	{
		typeof(Vector3),
		typeof(CardData),
		typeof(bool),
		typeof(bool),
		typeof(bool),
		typeof(bool)
	})]
	[HarmonyPostfix]
	public static void WorldManager_CreateCard_Postfix(Vector3 position, CardData cardDataPrefab, CardData __result)
	{
		//__result.AddVariationData(new CardVariationTrembling());
		if (!cardDataPrefab.IsVariation()) return;
		foreach (CardVariationData variation in cardDataPrefab.GetVariationList())
		{
			__result.AddVariationData(variation.GetCopy());
		}
	}
	[HarmonyPatch(typeof(GameCard), "Start")]
	[HarmonyPostfix]
	public static void GameCard_Start_Postfix(GameCard __instance)
	{
		if (__instance.CardData == null || !__instance.CardData.IsVariation()) return;
		foreach (CardVariationData variation in __instance.CardData.GetVariationList())
		{
			variation.OnCardStart(__instance);
		}
	}

}
