namespace CatRPG {

    public class AudioClip {

        private readonly int source;
        private readonly int buffer;

        public AudioClip (int source, int buffer) {
            this.source = source;
            this.buffer = buffer;
        }

        public int GetBuffer () {
            return this.buffer;
        }

        public int GetSource () {
            return this.source;
        }

    }

}