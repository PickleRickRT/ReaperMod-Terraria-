using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;


namespace ReaperMod.Projectiles
{
    public class RBullet1 : ModProjectile
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.ReaperMod.hjson file.
        int bounce = 0;
        int maxbounce = 2;
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 4;
            Projectile.height = 20;
            Projectile.aiStyle = 1; //1:IA pour les flèches
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 400;
            Projectile.light = 0;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.scale = 0.7f;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            Projectile.aiStyle = 0;//hack pour que la texture soit dans le bon sens
            //dust
            int dust = Dust.NewDust(Projectile.Center, Projectile.width/2, Projectile.height/2, DustID.Ice_Purple, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0.3f;
            Main.dust[dust].scale = (float)Main.rand.Next(80,115) * 0.013f;
            //lighting
            Lighting.AddLight(Projectile.position, 0.6f, 0.05f, 0.65f);
        }

        public override void OnKill(int timeLeft)
        {
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i<3; i++)
            {
                Dust.NewDust(Projectile.position,Projectile.width,Projectile.height,DustID.WoodFurniture,0f,0f,0,default(Color),1f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounce += 1;
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width/3, Projectile.height/3, DustID.WoodFurniture, 0f, 0f, 0, default(Color), 1f);
            }
            if (Projectile.velocity.X!= oldVelocity.X) { Projectile.velocity.X = -0.7f*oldVelocity.X;}
            if (Projectile.velocity.Y != oldVelocity.Y) { Projectile.velocity.Y = -0.7f * oldVelocity.Y; }
            Projectile.aiStyle = 1;
            if(bounce>=maxbounce) { return true; }
            else { return false; }
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