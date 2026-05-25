using DiskCardGame;
using InscryptionAPI.Card;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace MoDecks;

public static class Tools
{
  public static Texture2D LoadTex(string path)
  {
    byte[] embeddedResource = Tools.ExtractEmbeddedResource(path);
    Texture2D texture2D = new Texture2D(2, 2);
    ImageConversion.LoadImage(texture2D, embeddedResource);
    texture2D.filterMode = (FilterMode) 0;
    return texture2D;
  }

  public static byte[] ExtractEmbeddedResource(string filePath)
  {
    filePath = filePath.Replace("/", ".");
    filePath = filePath.Replace("\\", ".");
    using (Stream manifestResourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream(filePath))
    {
      if (manifestResourceStream == null)
        return (byte[]) null;
      byte[] buffer = new byte[manifestResourceStream.Length];
      manifestResourceStream.Read(buffer, 0, buffer.Length);
      return buffer;
    }
  }

  public static Sprite ConvertTexToSprite(Texture2D tex, Vector2? pivot = null)
  {
    Vector2 vector2;
    vector2 = new Vector2(0.5f, 0.5f);
    if (pivot.HasValue)
    {
      vector2 = new Vector2(pivot.Value.x, pivot.Value.y);
    }
    tex.filterMode = (FilterMode) 0;
    return Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), vector2, 100f);
  }

  public static AbilityInfo MakeNewSigil(
    string name,
    string description,
    Type behaviour,
    List<AbilityMetaCategory> categories = null,
    int powerLevel = 0,
    bool stackable = false,
    bool opponentUsable = false,
    Texture tex = null,
    Texture2D pixelTex = null,
    bool isConduit = false,
    bool isActivated = false)
  {
    AbilityInfo abilityInfo = AbilityManager.New("sire.inscryption.modecks", name, description, behaviour, (tex != null) ? tex : Tools.LoadTex("MoSigils/SigilArt/sirecoolsigil.png"));    abilityInfo.powerLevel = powerLevel;
    abilityInfo.canStack = stackable;
    abilityInfo.opponentUsable = opponentUsable;
	  if (pixelTex != null) 
    {
		  abilityInfo.pixelIcon = Tools.ConvertTexToSprite(pixelTex, null);
	  }
    abilityInfo.metaCategories = categories != null ? categories : new List<AbilityMetaCategory>();
    abilityInfo.conduit = isConduit;
    abilityInfo.activated = isActivated;
    return abilityInfo;
  }
}
