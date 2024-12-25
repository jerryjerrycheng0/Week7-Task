using UnityEngine;
using GameDevWithMarco.Singleton;
using GameDevWithMarco.Player;

namespace GameDevWithMarco.Managers
{
    public class Music : Singleton<Music>
    {
        [SerializeField] AudioSource moosic;
        private void Start()
        {
            moosic.pitch = 1f; // Ensure the music is at normal pitch
            moosic.Play();
        }

    }
}
