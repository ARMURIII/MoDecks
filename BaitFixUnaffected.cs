using System;
using System.Collections;
using System.Collections.Generic;
using DiskCardGame;
using UnityEngine;

namespace MoDecks
{
	// Token: 0x02000004 RID: 4
	public class BaitFixUnaffected : AbilityBehaviour
	{
		// Token: 0x0600000B RID: 11 RVA: 0x0000383C File Offset: 0x00001A3C
		public static void Init()
		{
			AbilityInfo abilityInfo = Tools.MakeNewSigil("Transferrable Shark Bait", "When this card perishes, a Great White takes its place, this variant can be Transferred in Altar Stones.", typeof(BaitFixUnaffected), new List<AbilityMetaCategory>
			{
				0
			}, 5, false, false, Tools.LoadTex("MoDecks/SigilArt/BaitSigil2.png"), Tools.LoadTex("MoDecks/SigilArt/PixelBait2.png"), false, false);
			BaitFixUnaffected.ability = abilityInfo.ability;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00003898 File Offset: 0x00001A98
		public override Ability Ability
		{
			get
			{
				return BaitFixUnaffected.ability;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000038B0 File Offset: 0x00001AB0
		public override bool RespondsToDie(bool wasSacrifice, PlayableCard killer)
		{
			return !wasSacrifice;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000038C6 File Offset: 0x00001AC6
		public override IEnumerator OnDie(bool wasSacrifice, PlayableCard killer)
		{
			yield return this.BreakCage(true);
			yield break;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000038E3 File Offset: 0x00001AE3
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

		// Token: 0x04000007 RID: 7
		public static Ability ability;
	}
}
