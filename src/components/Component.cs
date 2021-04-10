namespace CatRPG {
    public class Component {

        private bool isActive = false;
        private GameObject gameObject = null;

        public Component () { }

        public void AssignGameObject (GameObject gameObject) {
            this.gameObject = gameObject;
        }

        public void SetActive (bool result) {
            this.isActive = result;
            if (result) {
                this.Start ();
            }
        }

        public virtual void Start () { }

        public virtual void Update () { }
    }

}