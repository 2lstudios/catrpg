namespace CatRPG {

    public class Texture2D {

        private int id;
        private int width;
        private int height;

        public Texture2D (int id, int width, int height) {
            this.id = id;
            this.width = width;
            this.height = height;
        }

        public int ID { get { return id; } }
        public int Width { get { return width; } }
        public int Height { get { return height; }}
    }

}