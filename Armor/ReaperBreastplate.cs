using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReaperMod.Armor
    {
    [AutoloadEquip(EquipType.Body)]
    public class ReaperBreastplate : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightPurple;
            Item.defense = 4;

        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= 1.1f;
            player.GetModPlayer<GlobalPlayer>().ReaperDamage += 0.05f;

        }
    }
}