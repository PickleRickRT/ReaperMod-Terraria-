using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace ReaperMod.Projectiles
{
    public class YellowScythe : ModProjectile
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.aiStyle = 0; //0:projectile non affecté par la gravité
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 25;
            Projectile.timeLeft = 600;
            Projectile.light = 2;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            DrawOffsetX = 5;
            DrawOriginOffsetY = 5;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 15, 15, DustID.JungleSpore, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0.3f;
            Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.026f;
            
            //cycle throught the frame sheet
            if (++Projectile.frameCounter >= 2)//switch frame each 2 ingame frames (30fps)  
            {
                Projectile.frameCounter = 0;
                // Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
        }

        public void FadeInAndOut()
        {
            // If last less than 50 ticks — fade in, than more — fade out
            if (Projectile.ai[0] <= 50f)
            {
                // Fade in
                Projectile.alpha -= 25;
                // Cap alpha before timer reaches 50 ticks
                if (Projectile.alpha < 50)
                    Projectile.alpha = 50;

                return;
            }
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