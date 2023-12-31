using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReaperMod;

namespace ReaperMod.Accessories
{
    public class ReaperSigil : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
	        Item.height = 20;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightPurple;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //base.UpdateAccessory(player, hideVisual); pour que l'accéssoire s'affiche sur le joueur
            //player.GetModPlayer<GlobalPlayer>().ReaperDamage += 1;
            player.moveSpeed += 0.1f;
            player.accRunSpeed += 0.1f;
            player.GetModPlayer<GlobalPlayer>().sigil = true;
        }
    }
}
