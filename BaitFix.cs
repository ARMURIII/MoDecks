using System;
using System.Collections;
using System.Collections.Generic;
using DiskCardGame;
using UnityEngine;

namespace MoDecks
{
	// Token: 0x02000003 RID: 3
	public class BaitFix : AbilityBehaviour
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00003774 File Offset: 0x00001974
		public static void Init()
		{
			AbilityInfo abilityInfo = Tools.MakeNewSigil("Shark Bait", "When this card perishes, a Great White takes its place.", typeof(BaitFix), new List<AbilityMetaCategory>
			{
				0
			}, 5, false, false, Tools.LoadTex("MoDecks/SigilArt/BaitSigil.png"), Tools.LoadTex("MoDecks/SigilArt/PixelBait.png"), false, false);
			BaitFix.ability = abilityInfo.ability;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000037D0 File Offset: 0x000019D0
		public override Ability Ability
		{
			get
			{
				return BaitFix.ability;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000037E8 File Offset: 0x000019E8
		public override bool RespondsToDie(bool wasSacrifice, PlayableCard killer)
		{
			return !wasSacrifice;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000037FE File Offset: 0x000019FE
		public override IEnumerator OnDie(bool wasSacrifice, PlayableCard killer)
		{
			yield return this.BreakCage(true);
			yield break;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000381B File Offset: 0x00001A1B
		private IEnumerator BreakCage(bool fromBattle)
		{
			string creatureWithinId = "Shark";
			if (fromBattle)
			{
				yield return new WaitForSeconds(1f);
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName(creatureWithinId), base.Card.Slot, 0.15f, true);
			}
			yield return new WaitForSeconds(1f);
			yield break;
		}

		// Token: 0x04000006 RID: 6
		public static Ability ability;
	}
}
