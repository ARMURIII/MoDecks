using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using DiskCardGame;
using HarmonyLib;
using InscryptionAPI.Ascension;
using InscryptionAPI.Card;
using UnityEngine;

namespace MoDecks
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("sire.inscryption.modecks", "MoDecks", "1.4.2")]
	[BepInDependency("cyantist.inscryption.api", BepInEx.BepInDependency.DependencyFlags.HardDependency)]
	public class Plugin : BaseUnityPlugin
	{
		
		private const string PluginGuid = "sire.inscryption.modecks";

		private const string PluginName = "MoDecks";

		private const string PluginVersion = "1.4.2";

		public static ConfigEntry<bool> configAct2Beasts;

		public static ConfigEntry<bool> configSharkBaitTransfer;

		private void Awake()
		{
			base.Logger.LogInfo("Loaded MoDecks!");
			Harmony harmony = new Harmony("sire.modecks.harmonypatcher");
			harmony.PatchAll();
			this.HandleConfig();
			BaitFix.Init();
			BaitFixUnaffected.Init();
			CardExtensions.AddAppearances(CardExtensions.AddTraits(CardExtensions.SetPixelPortrait(CardExtensions.SetPortrait(CardManager.New("MoDeck", "MoDeck_DamGod", "God Dam", 1, 4, "How did you find me?"), Tools.LoadTex("MoDecks/Resources/MoDeckDam.png"), null), Tools.LoadTex("MoDecks/Resources/PixelGodDam.png"), null), new Trait[]
			{
				(Trait) 12
			}), new CardAppearanceBehaviour.Appearance[]
			{
				(CardAppearanceBehaviour.Appearance) 2
			});
			StarterDeckInfo starterDeckInfo = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo.title = "Prospector's Beasts";
			starterDeckInfo.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/NewDeckIcons/ProspectorDeck.png"), null);
			starterDeckInfo.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Mule"),
				CardLoader.GetCardByName("Bloodhound"),
				CardLoader.GetCardByName("Coyote")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo, 0);
			StarterDeckInfo starterDeckInfo2 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo2.title = "Angler's Fish";
			starterDeckInfo2.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/AnglerDeck.png"), null);
			starterDeckInfo2.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Kingfisher"),
				CardLoader.GetCardByName("BaitBucket"),
				CardLoader.GetCardByName("Salmon")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo2, 0);
			StarterDeckInfo starterDeckInfo3 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo3.title = "Scurvy Crew";
			starterDeckInfo3.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/RoyalDeck.png"), null);
			starterDeckInfo3.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("SkeletonPirate"),
				CardLoader.GetCardByName("SkeletonParrot"),
				CardLoader.GetCardByName("MoleSeaman")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo3, 12);
			StarterDeckInfo starterDeckInfo4 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo4.title = "Trapper's Cards";
			starterDeckInfo4.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/NewDeckIcons/TrapDeckv2.png"), null);
			starterDeckInfo4.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Lice"),
				CardLoader.GetCardByName("TrapFrog"),
				CardLoader.GetCardByName("Bullfrog")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo4, 11);
			StarterDeckInfo starterDeckInfo5 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo5.title = "Grimora's Dead";
			starterDeckInfo5.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/GrimoraDeck.png"), null);
			starterDeckInfo5.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("CatUndead"),
				CardLoader.GetCardByName("SkeletonPirate"),
				CardLoader.GetCardByName("Smoke")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo5, 11);
			StarterDeckInfo starterDeckInfo6 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo6.title = "GBCTrapper's Set";
			starterDeckInfo6.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/NewDeckIcons/PixelTrapper.png"), null);
			starterDeckInfo6.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("BurrowingTrap"),
				CardLoader.GetCardByName("Bullfrog"),
				CardLoader.GetCardByName("Coyote")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo6, 0);
			StarterDeckInfo starterDeckInfo7 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo7.title = "Mothmen v2";
			starterDeckInfo7.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/EvolutionDeck3.png"), null);
			starterDeckInfo7.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Mothman_Stage1"),
				CardLoader.GetCardByName("Porcupine"),
				CardLoader.GetCardByName("Amoeba")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo7, 5);
			StarterDeckInfo starterDeckInfo8 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo8.title = "Act2 Waterborne";
			starterDeckInfo8.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/Act2WaterDeck.png"), null);
			starterDeckInfo8.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Salmon"),
				CardLoader.GetCardByName("Shark"),
				CardLoader.GetCardByName("Kraken")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo8, 11);
			StarterDeckInfo starterDeckInfo9 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo9.title = "I spy with my little Magpie's Eye";
			starterDeckInfo9.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/MagpieDeck.png"), null);
			starterDeckInfo9.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Magpie"),
				CardLoader.GetCardByName("Cuckoo"),
				CardLoader.GetCardByName("Sparrow")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo9, 2);
			StarterDeckInfo starterDeckInfo10 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo10.title = "Strafe Deck";
			starterDeckInfo10.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/NEWStrafeDeck.png"), null);
			starterDeckInfo10.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("SquirrelBall"),
				CardLoader.GetCardByName("ElkCub"),
				CardLoader.GetCardByName("Bull")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo10, 2);
			StarterDeckInfo starterDeckInfo11 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo11.title = "D.E.B Deers Eat Blood";
			starterDeckInfo11.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/SacrificialDeck.png"), null);
			starterDeckInfo11.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("RedHart"),
				CardLoader.GetCardByName("Warren"),
				CardLoader.GetCardByName("FieldMouse")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo11, 9);
			StarterDeckInfo starterDeckInfo12 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo12.title = "Stinky Men";
			starterDeckInfo12.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/DefenseDeck.png"), null);
			starterDeckInfo12.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("MoleMan"),
				CardLoader.GetCardByName("Skunk"),
				CardLoader.GetCardByName("Beehive")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo12, 0);
			StarterDeckInfo starterDeckInfo13 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo13.title = "Defensive Reptiles";
			starterDeckInfo13.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/DefensiveDeck.png"), null);
			starterDeckInfo13.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Bullfrog"),
				CardLoader.GetCardByName("Snapper"),
				CardLoader.GetCardByName("MudTurtle")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo13, 4);
			StarterDeckInfo starterDeckInfo14 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo14.title = "Kraken's Tentacles";
			starterDeckInfo14.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/SquidDeck.png"), null);
			starterDeckInfo14.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("SquidMirror"),
				CardLoader.GetCardByName("SquidCards"),
				CardLoader.GetCardByName("SquidBell")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo14, 3);
			StarterDeckInfo starterDeckInfo15 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo15.title = "Strike Deck";
			starterDeckInfo15.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/AttackDeck.png"), null);
			starterDeckInfo15.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("DireWolf"),
				CardLoader.GetCardByName("Pronghorn"),
				CardLoader.GetCardByName("Mantis")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo15, 5);
			StarterDeckInfo starterDeckInfo16 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo16.title = "Old Moth, Men and Mothmen";
			starterDeckInfo16.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/OldMothManDeck.png"), null);
			starterDeckInfo16.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Mothman_Stage1"),
				CardLoader.GetCardByName("Mothman_Stage2"),
				CardLoader.GetCardByName("Mothman_Stage3")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo16, 6);
			StarterDeckInfo starterDeckInfo17 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo17.title = "Bloodless";
			starterDeckInfo17.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/TerrainDeck.png"), null);
			starterDeckInfo17.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("MoDeck_DamGod"),
				CardLoader.GetCardByName("Boulder"),
				CardLoader.GetCardByName("FrozenOpossum")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo17, 0);
			StarterDeckInfo starterDeckInfo18 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo18.title = "Insect Infestation";
			starterDeckInfo18.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/NewDeckIcons/UnkillableDecv2.png"), null);
			starterDeckInfo18.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Cockroach"),
				CardLoader.GetCardByName("Mantis"),
				CardLoader.GetCardByName("RingWorm")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo18, 0);
			StarterDeckInfo starterDeckInfo19 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo19.title = "Hand Deck";
			starterDeckInfo19.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/NewDeckIcons/CardDeckv2.png"), null);
			starterDeckInfo19.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("SquidCards"),
				CardLoader.GetCardByName("Warren"),
				CardLoader.GetCardByName("FieldMouse")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo19, 3);
			StarterDeckInfo starterDeckInfo20 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo20.title = "Rats! Rats! we are the Rats!";
			starterDeckInfo20.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/NEWRatDeck.png"), null);
			starterDeckInfo20.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("PackRat"),
				CardLoader.GetCardByName("FieldMouse"),
				CardLoader.GetCardByName("RatKing")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo20, 0);
			StarterDeckInfo starterDeckInfo21 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo21.title = "Trash Beasts";
			starterDeckInfo21.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/TrashDeck.png"), null);
			starterDeckInfo21.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Stoat"),
				CardLoader.GetCardByName("Sparrow"),
				CardLoader.GetCardByName("Bat")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo21, 0);
			StarterDeckInfo starterDeckInfo22 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo22.title = "Alternative Bones";
			starterDeckInfo22.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/NewDeckIcons/LammergierDeck.png"), null);
			starterDeckInfo22.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Lammergeier"),
				CardLoader.GetCardByName("Warren"),
				CardLoader.GetCardByName("DireWolfCub")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo22, 9);
			StarterDeckInfo starterDeckInfo23 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo23.title = "OLD_DECK";
			starterDeckInfo23.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/RandomDeck.png"), null);
			starterDeckInfo23.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("!STATIC!GLITCH"),
				CardLoader.GetCardByName("!STATIC!GLITCH"),
				CardLoader.GetCardByName("!STATIC!GLITCH")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo23, 0);
			StarterDeckInfo starterDeckInfo24 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo24.title = "Long Problems require Longer Solutions";
			starterDeckInfo24.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/StrafeBones2.png"), null);
			starterDeckInfo24.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Snelk_Neck"),
				CardLoader.GetCardByName("Snelk_Neck"),
				CardLoader.GetCardByName("Snelk")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo24, 0);
			StarterDeckInfo starterDeckInfo25 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo25.title = "God Dam!";
			starterDeckInfo25.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/NewDeckIcons/AlphaDams.png"), null);
			starterDeckInfo25.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Beaver"),
				CardLoader.GetCardByName("Alpha"),
				CardLoader.GetCardByName("Warren")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo25, 0);
			StarterDeckInfo starterDeckInfo26 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo26.title = "Bell Deck";
			starterDeckInfo26.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/NewDeckIcons/BellDeckv2.png"), null);
			starterDeckInfo26.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("SquidBell"),
				CardLoader.GetCardByName("Daus"),
				CardLoader.GetCardByName("DausBell")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo26, 0);
			StarterDeckInfo starterDeckInfo27 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo27.title = "Shapeshifter's Deck";
			starterDeckInfo27.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/IjiraqDeck.png"), null);
			starterDeckInfo27.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Ijiraq"),
				CardLoader.GetCardByName("RatKing"),
				CardLoader.GetCardByName("Adder")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo27, 3);
			StarterDeckInfo starterDeckInfo28 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo28.title = "Fawns, Cubs and Eggs";
			starterDeckInfo28.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/EvolutionDeck2.png"), null);
			starterDeckInfo28.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("WolfCub"),
				CardLoader.GetCardByName("ElkCub"),
				CardLoader.GetCardByName("RavenEgg")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo28, 0);
			StarterDeckInfo starterDeckInfo29 = ScriptableObject.CreateInstance<StarterDeckInfo>();
			starterDeckInfo29.title = "Hodag's Deck";
			starterDeckInfo29.iconSprite = Tools.ConvertTexToSprite(Tools.LoadTex("MoDecks/DeckIcons/NEWVisciousDeck.png"), null);
			starterDeckInfo29.cards = new List<CardInfo>
			{
				CardLoader.GetCardByName("Hodag"),
				CardLoader.GetCardByName("Wolverine"),
				CardLoader.GetCardByName("Wolf")
			};
			StarterDeckManager.Add("sire.inscryption.modecks", starterDeckInfo29, 11);
			CardExtensions.SetPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Salmon"), Tools.LoadTex("MoDecks/Resources/inscryption-salmon.png"), null);
			CardExtensions.SetPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "SquirrelBall"), Tools.LoadTex("MoDecks/Resources/portrait_squirrelball.png"), null);
			CardExtensions.SetPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Hawk"), Tools.LoadTex("MoDecks/Resources/Act1Hawk.png"), null);
			CardExtensions.SetPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "BurrowingTrap"), Tools.LoadTex("MoDecks/Resources/Act1BurrowingTrap.png"), null);
			CardExtensions.AddAppearances(CardExtensions.CardByName(CardManager.BaseGameCards, "BurrowingTrap"), new CardAppearanceBehaviour.Appearance[]
			{
				(DiskCardGame.CardAppearanceBehaviour.Appearance)2,
				(DiskCardGame.CardAppearanceBehaviour.Appearance)9
			});
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Ijiraq"), Tools.LoadTex("MoDecks/Resources/pixelportrait_moleman_ijiraq.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Smoke"), Tools.LoadTex("MoDecks/Resources/syntax_smoke.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Mule"), Tools.LoadTex("MoDecks/Resources/PixelMule.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "BaitBucket"), Tools.LoadTex("MoDecks/Resources/syntax_baitbucket.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Snelk"), Tools.LoadTex("MoDecks/Resources/syntax_snelk_head.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Snelk_Neck"), Tools.LoadTex("MoDecks/Resources/syntax_snelk_neck.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "!STATIC!GLITCH"), Tools.LoadTex("MoDecks/Resources/Static.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Bat"), Tools.LoadTex("MoDecks/Resources/syntax_bat.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "PackRat"), Tools.LoadTex("MoDecks/Resources/syntax_packrat.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "FrozenOpossum"), Tools.LoadTex("MoDecks/Resources/syntax_frozenopossum.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Boulder"), Tools.LoadTex("MoDecks/Resources/PixelBoulder.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Cockroach"), Tools.LoadTex("MoDecks/Resources/syntax_cockroach.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Mantis"), Tools.LoadTex("MoDecks/Resources/syntax_mantis.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Pronghorn"), Tools.LoadTex("MoDecks/Resources/syntax_pronghorn.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Snapper"), Tools.LoadTex("MoDecks/Resources/syntax_turtle.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Beehive"), Tools.LoadTex("MoDecks/Resources/syntax_beehive.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Sparrow"), Tools.LoadTex("MoDecks/Resources/syntax_sparrow.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Shark"), Tools.LoadTex("MoDecks/Resources/syntax_shark.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Beaver"), Tools.LoadTex("MoDecks/Resources/syntax_beaver.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Daus"), Tools.LoadTex("MoDecks/Resources/syntax_daus.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "DausBell"), Tools.LoadTex("MoDecks/Resources/syntax_dauschime.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "TrapFrog"), Tools.LoadTex("MoDecks/Resources/extraordinora_strangefrog.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "SkeletonPirate"), Tools.LoadTex("MoDecks/Resources/fixedCrew.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "SkeletonParrot"), Tools.LoadTex("MoDecks/Resources/syntax_skeletonparrot.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "MoleSeaman"), Tools.LoadTex("MoDecks/Resources/PixelSeaman.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "RavenEgg"), Tools.LoadTex("MoDecks/Resources/syntax_ravenegg.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Mothman_Stage1"), Tools.LoadTex("MoDecks/Resources/syntax_mothman1.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Mothman_Stage2"), Tools.LoadTex("MoDecks/Resources/syntax_mothman2.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Mothman_Stage3"), Tools.LoadTex("MoDecks/Resources/syntax_mothman3.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Porcupine"), Tools.LoadTex("MoDecks/Resources/syntax_porcupine.png"), null);
			CardExtensions.SetPixelPortrait(CardExtensions.CardByName(CardManager.BaseGameCards, "Amoeba"), Tools.LoadTex("MoDecks/Resources/syntax_amoeba.png"), null);
			CardExtensions.CardByName(CardManager.BaseGameCards, "SkeletonPirate").SetBonesCost(2);
			CardExtensions.CardByName(CardManager.BaseGameCards, "SkeletonParrot").SetBonesCost(2);
			CardExtensions.CardByName(CardManager.BaseGameCards, "MoleSeaman").SetBloodCost(2);
			CardExtensions.CardByName(CardManager.BaseGameCards, "Mothman_Stage2").SetBloodCost(3);
			CardExtensions.CardByName(CardManager.BaseGameCards, "Mothman_Stage3").SetBloodCost(4);
			CardExtensions.CardByName(CardManager.BaseGameCards, "BaitBucket").SetBloodCost(1);
			CardExtensions.CardByName(CardManager.BaseGameCards, "Mule").SetBloodCost(2);
			CardExtensions.CardByName(CardManager.BaseGameCards, "CatUndead").SetBloodCost(0);
			CardExtensions.CardByName(CardManager.BaseGameCards, "CatUndead").SetBonesCost(9);
			if (Plugin.configSharkBaitTransfer.Value)
			{
				CardExtensions.AddAbilities(CardExtensions.CardByName(CardManager.BaseGameCards, "BaitBucket"), new Ability[]
				{
					BaitFixUnaffected.ability
				});
			}
			else
			{
				CardExtensions.AddAbilities(CardExtensions.CardByName(CardManager.BaseGameCards, "BaitBucket"), new Ability[]
				{
					BaitFix.ability
				});
			}
			if (Plugin.configAct2Beasts.Value)
			{
				CardExtensions.AddMetaCategories(CardExtensions.CardByName(CardManager.BaseGameCards, "Salmon"), new CardMetaCategory[1]);
				CardExtensions.AddMetaCategories(CardExtensions.CardByName(CardManager.BaseGameCards, "SquirrelBall"), new CardMetaCategory[1]);
				CardExtensions.AddMetaCategories(CardExtensions.CardByName(CardManager.BaseGameCards, "Hawk"), new CardMetaCategory[1]);
				CardExtensions.CardByName(CardManager.BaseGameCards, "Salmon").description = "The slippery Salmon, fighting whatever current flows against them.";
				CardExtensions.CardByName(CardManager.BaseGameCards, "SquirrelBall").description = "Bizarre to think that a group of Squirrels would do this...";
				CardExtensions.CardByName(CardManager.BaseGameCards, "Hawk").description = "The attentive Hawk, well trained and deadly, if a bit fragile.";
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00003718 File Offset: 0x00001918
		private void HandleConfig()
		{
			Plugin.configAct2Beasts = base.Config.Bind<bool>("General", "Act2Beasts_into_KCM", true, "Makes it so if enabled, Act 2 beast cards are added into the KCM card pool.");
			Plugin.configSharkBaitTransfer = base.Config.Bind<bool>("General", "Transferrable_SharkBait", false, "Makes it so if enabled, The Shark Bait sigil is an option for sacrifice stones.");
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00003768 File Offset: 0x00001968
		private void Start()
		{
		}

		// Token: 0x02000006 RID: 6
		[HarmonyPatch(typeof(CardMergeSequencer), "GetValidCardsForSacrifice")]
		public class SacStoneSacrifice_patch
		{
			// Token: 0x06000015 RID: 21 RVA: 0x00003ADC File Offset: 0x00001CDC
			[HarmonyPostfix]
			public static void Postfix(ref List<CardInfo> __result)
			{
				List<CardInfo> list = __result;
				list.RemoveAll((CardInfo x) => x.Abilities.Contains((DiskCardGame.Ability)30) || x.Abilities.Contains(BaitFix.ability));
				__result = list;
			}
		}

		// Token: 0x02000007 RID: 7
		[HarmonyPatch(typeof(CardStatBoostSequencer), "GetValidCards")]
		public class CampfireBoost_patch
		{
			// Token: 0x06000017 RID: 23 RVA: 0x00003B20 File Offset: 0x00001D20
			[HarmonyPostfix]
			public static void Postfix(ref List<CardInfo> __result)
			{
				List<CardInfo> list = __result;
				list.RemoveAll((CardInfo x) => x.Abilities.Contains((DiskCardGame.Ability)30) || x.Abilities.Contains(BaitFix.ability));
				__result = list;
			}
		}

		// Token: 0x02000008 RID: 8
		[HarmonyPatch(typeof(PackMule), "RespondsToResolveOnBoard")]
		public class PackMulePatch
		{
			// Token: 0x06000019 RID: 25 RVA: 0x00003B63 File Offset: 0x00001D63
			[HarmonyPostfix]
			public static void Postfix(ref bool __result)
			{
				__result = true;
			}
		}
	}
}