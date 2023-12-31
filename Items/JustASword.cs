using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReaperMod.Items
{
	public class JustASword : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.crit = 54;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 12;
			Item.value = 10000;
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
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