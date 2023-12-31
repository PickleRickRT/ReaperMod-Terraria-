using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace ReaperMod
{
	public class GlobalPlayer : ModPlayer
	{
	public bool sigil = false;
        public float judgement = 0f;
        public int JudgementCharge = 0;
	public float ReaperDamage = 0f;
        public float ReaperCrit = 0f;
        public override void PostUpdate()
        {
            if ((Player.velocity.X != 0 || Player.velocity.Y != 0) && sigil)
            {
                int dust = Dust.NewDust(Player.position, Player.width, Player.height, DustID.Wraith, 0f, 0f, 0, default);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 0.7f;
            }
        }
        public override void ResetEffects()
        {
            ReaperDamage = 0f;
            ReaperCrit = 0f;   //reset Stats
            sigil = false;
    }
    }
	
}
