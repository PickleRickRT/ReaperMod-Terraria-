using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReaperMod.Items
{
	public class CrossSpear : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Spear);
			Item.damage = 33;
			Item.crit = 25;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.knockBack = 5;
			Item.value = 250000;
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.CrossSpearProjectile>();
		}

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Bleeding,300);
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.CrossSpearProjectile>()] < 1;
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