using System;
using System.Drawing;
using System.Drawing.Imaging;
using NVorbis;
using OpenTK.Graphics.OpenGL;

namespace CatRPG {
    public static class ResourceLoader {

        public static AudioClip LoadAudioClip (string filePath) {
            using (var vorbis = new VorbisReader (filePath)) {
                var channels = vorbis.Channels;
                var sampleRate = vorbis.SampleRate;
                var totalTime = vorbis.TotalTime;
                var readBuffer = new float[channels * sampleRate / 5];
                var position = TimeSpan.Zero;

                int cnt;
                while ((cnt = vorbis.ReadSamples (readBuffer, 0, readBuffer.Length)) > 0) {
                    Console.WriteLine ("uwu");
                    position = vorbis.TimePosition;
                }

                return new AudioClip (0, 0);
            }
        }

        public static Texture2D LoadTexture (string filePath) {
            Bitmap bitmap = new Bitmap (filePath);
            int texture;
            GL.GenTextures (1, out texture);
            GL.BindTexture (TextureTarget.Texture2D, texture);
            GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int) TextureMinFilter.Linear);
            GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int) TextureMagFilter.Linear);
            BitmapData data = bitmap.LockBits (new System.Drawing.Rectangle (0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D (TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits (data);
            return new Texture2D (texture, bitmap.Width, bitmap.Height);
        }
    }

}