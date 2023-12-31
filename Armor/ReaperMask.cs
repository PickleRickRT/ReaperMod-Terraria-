using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReaperMod.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ReaperMask : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.
        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; //Hide player's head
        }
        public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightPurple;
			Item.defense = 3;
			
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ReaperBreastplate>() && legs.type == ModContent.ItemType<ReaperLeggings>();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<GlobalPlayer>().ReaperDamage += 0.05f; //Reaper Damage +5%
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases armor penetration by 5"; // This is the setbonus tooltip
            player.GetArmorPenetration(DamageClass.Generic) += 5; //ArmorPenetratrion + 5
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