using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using ReaperMod.Projectiles;
using System.Collections.Generic;
using System.Linq;

namespace ReaperMod.Items
{
    public class DeathPistol : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1;
            Item.value = 32000;
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 7.5f;
            Item.scale = 0.7f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 3, velocity.Y * 3);
            position += offset;
            return true;            
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Bullet)
            { // or ProjectileID.WoodenArrowFriendly
                type = ModContent.ProjectileType<RBullet1>(); // or ProjectileID.FireArrow;
            }

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
            return new Vector2(-2, 0);
        }

    }
}
