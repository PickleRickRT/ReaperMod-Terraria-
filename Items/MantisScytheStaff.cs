using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using ReaperMod.Projectiles;
using System.Collections.Generic;
using System.Linq;

namespace ReaperMod.Items
{
	
	public class MantisScytheStaff : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.
		public override void SetStaticDefaults()
		{
			Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
		}
		public override void SetDefaults()
		{
			Item.DefaultToStaff(ModContent.ProjectileType<Projectiles.YellowScythe>(), 12, 25, 5);
			//Item.DefaultToStaff(Projectile's ID,Projectile's speed,Projectile's duration,ManaCost)
			Item.UseSound = SoundID.Item20;
			Item.SetWeaponValues(5, 3); //(Damage, knockback)
			Item.SetShopValues(ItemRarityColor.Green2, 10000); //(Rarity,Price)
			Item.scale = 0.5f;
			Item.crit = 10;
		}

        //les fonctions ModifyTooltips ModifyWeaponDamage et ModifyWeaponCrit servent à mettre l'arme dans la nouvelle classe
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var lineToChange =  tooltips.FirstOrDefault(x=>x.Name=="Damage" && x.Mod == "Terraria");
			if (lineToChange != null)
			{
				string[]split =lineToChange.Text.Split(' ');
				lineToChange.Text= split.First()+" Reaper " + split.Last();
			}
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            damage += player.GetModPlayer<GlobalPlayer>().ReaperDamage;
        }

        public override void ModifyWeaponCrit(Player player, ref float crit)
        {
            crit += player.GetModPlayer<GlobalPlayer>().ReaperCrit;
        }

        /*
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Vector2 offset = new Vector2(velocity.X * 20, velocity.Y * 20);
			position += offset;
			return true;
        }
		*/
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Lens, 15);
			recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddIngredient(ItemID.Wood, 35);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}



	}
}
