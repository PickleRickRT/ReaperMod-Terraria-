using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReaperMod.Items
{
	public class JustAPaxe : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.

		public override void SetDefaults()
		{
			Item.damage = 7000;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightPurple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.pick = 600;
			Item.axe = 250;
			Item.hammer = 600;
			Item.useTurn = true;
			Item.scale = 3;
			Item.noMelee = true;
		}

		//public override void AddRecipes()
		//{
		//Recipe recipe = CreateRecipe();
		//recipe.AddIngredient(ItemID.DirtBlock, 10);
		//recipe.AddTile(TileID.WorkBenches);
		//recipe.Register();
		//}
	}
}
