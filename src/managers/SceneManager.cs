using System;
using System.Collections.Generic;

namespace CatRPG {

    public class SceneManager {

        private Scene currentScene;
        private Dictionary<string, Scene> scenes = new Dictionary<string, Scene> ();
        private bool firstLoad = false;

        public void AddScene (string sceneName, Scene scene) {
            this.scenes.Add (sceneName, scene);
        }

        public void SetScene (string sceneName) {
            Scene targetScene = null;
            this.scenes.TryGetValue (sceneName, out targetScene);

            if (targetScene != null) {
                if (currentScene != null) {
                    currentScene.Disable ();
                }

                currentScene = targetScene;
                
                if (this.firstLoad) {
                    targetScene.Enable ();
                }
            }
        }

        public void FirstLoad () {
            this.firstLoad = true;
            if (this.currentScene != null) {
                this.currentScene.Enable();
            }
        }

        public void UpdateFrame () {
            if (this.currentScene != null) {
                this.currentScene.UpdateFrame ();
            }
        }

    }

}