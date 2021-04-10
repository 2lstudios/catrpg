using System;
using System.Collections.Generic;

namespace CatRPG {

    public class Scene {
        private List<GameObject> objects = new List<GameObject> ();
        private bool isActive;

        public void AddGameObject (GameObject gameObject) {
            gameObject.AssignScene (this);
            this.objects.Add (gameObject);

            if (this.isActive) {
                gameObject.SetActive (true);
            }
        }

        public void Disable () {
            this.isActive = false;

            foreach (GameObject gameObject in this.objects) {
                gameObject.SetActive (false);
            }
        }

        public void Enable () {
            this.isActive = true;

            foreach (GameObject gameObject in this.objects) {
                gameObject.SetActive (true);
            }
        }

        public void UpdateFrame () {
            if (this.isActive) {
                foreach (GameObject gameObject in this.objects) {
                    gameObject.Update ();
                }
            }
        }
    }

}