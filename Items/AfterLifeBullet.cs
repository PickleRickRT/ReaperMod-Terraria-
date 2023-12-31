using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using ReaperMod.Projectiles;

namespace ReaperMod.Items
{
    public class AfterLifeBullet : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.knockBack = 7;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<RBullet1>();
            Item.ammo = AmmoID.Bullet;
            Item.maxStack = 9999;
            Item.shootSpeed = 7.5f;
        }

        public override void AddRecipes()
        {
        Recipe recipe = CreateRecipe(25);
        recipe.AddIngredient(ItemID.DirtBlock, 10);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
        }
    }
}