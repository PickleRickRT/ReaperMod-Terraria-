using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using Microsoft.CodeAnalysis;
using ReaperMod.Projectiles;
using Terraria.DataStructures;

namespace ReaperMod.Items
{
	public class Glaive : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.crit = 54;
			Item.DamageType = DamageClass.Melee;
			Item.knockBack = 12;


			Item.width = 100;
			Item.height = 100;

			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = SoundID.Item1;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.channel = true;

			Item.shootSpeed = 50f;
			Item.shoot = ModContent.ProjectileType<Projectiles.GlaiveProjectile>();

			Item.value = 10000;
			Item.rare = ItemRarityID.LightPurple;

		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
           
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, velocity,type, damage, knockback, player.whoAmI );

			return false;
        }

        public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 3;
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