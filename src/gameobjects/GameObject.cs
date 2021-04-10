using System;
using System.Collections.Generic;

namespace CatRPG {

    public class GameObject {

        public readonly string name;

        private bool isActive = false;
        private List<Component> components = new List<Component> ();
        private Scene scene;

        public GameObject (string name) {
            this.name = name;
        }

        public void AddComponent (Component component) {
            component.AssignGameObject (this);
            this.components.Add (component);
            if (this.isActive) {
                component.SetActive (true);
            }
        }

        public void AssignScene (Scene scene) {
            this.scene = scene;
        }

        public Scene GetScene () {
            return this.scene;
        }

        public void SetActive (bool result) {
            this.isActive = result;
            if (result) {
                this.Start ();
            }
        }

        public virtual void Start () {
            foreach (Component component in this.components) {
                component.SetActive (true);
            }
        }

        public virtual void Update () {
            if (this.isActive) {
                foreach (Component component in this.components) {
                    component.Update ();
                }
            }
        }

    }
}