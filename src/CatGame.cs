using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CatRPG {
    public class CatGame : GameWindow {
        private readonly SceneManager sceneManager;
        private float updateFrameFrequency = 60.0f;

        public CatGame (int width, int height, string title) : base (width, height, GraphicsMode.Default, title) {
            this.sceneManager = new SceneManager ();
        }

        public SceneManager GetSceneManager () {
            return this.sceneManager;
        }

        public void SetUpdateFrameFrequency (float freq) {
            this.updateFrameFrequency = freq;
        }

        public void InitAndLockThread () {
            this.Run (this.updateFrameFrequency);
        }

        protected override void OnLoad (EventArgs e) {
            GL.ClearColor (1f, 1f, 1f, 1.0f);
            GL.Enable (EnableCap.Texture2D);
            GL.Hint (HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            this.sceneManager.FirstLoad ();
            base.OnLoad (e);
        }

        protected override void OnResize (EventArgs e) {
            GL.Viewport (0, 0, Width, Height);

            GL.MatrixMode (MatrixMode.Projection);
            GL.LoadIdentity ();
            GL.Ortho (-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnRenderFrame (FrameEventArgs e) {
            GL.Clear (ClearBufferMask.ColorBufferBit);
            this.sceneManager.UpdateFrame ();
            Input.UpdateInput ();
            Context.SwapBuffers ();
        }

        protected override void OnUpdateFrame (FrameEventArgs e) {
            base.OnUpdateFrame (e);
        }

    }
}