using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ReaperMod.Items
{
	public class OpticBow : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 120;
			Item.useAnimation = 120;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 10;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var lineToChange = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (lineToChange != null)
            {
                string[] split = lineToChange.Text.Split(' ');
                lineToChange.Text = split.First() + " Reaper " + split.Last();
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
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Lens, 15);
			recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddIngredient(ItemID.Wood, 35);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

	}
}