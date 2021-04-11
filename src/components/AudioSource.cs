using System;
using System.Diagnostics;
using System.Threading;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;

namespace CatRPG {
    public class AudioSource : CatRPG.Component {

        private AudioClip clip;
        private Thread thread;
        private bool playing = false;

        public AudioClip GetClip () {
            return this.clip;
        }

        public void SetClip (AudioClip clip) {
            this.clip = clip;
        }

        private void _AsyncPlay () {

        }

        public void Play () {
            this.thread = new Thread(this._AsyncPlay);
            this.thread.Start();
            this.playing = true;
        }

        public void Stop () {
            this.playing = false;
        }
    }
}