using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CatRPG {
    public static class Drawer {
        public static void DrawTexture (Texture2D texture) {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            GL.Begin(BeginMode.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-1.0f, -1.0f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(1.0f, -1.0f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(1.0f, 1.0f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-1.0f, 1.0f);

            GL.End();
        }
    }
}