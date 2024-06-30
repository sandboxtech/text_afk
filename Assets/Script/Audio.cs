
using UnityEngine;

namespace W
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AudioClip click;
        [SerializeField] private AudioClip on;
        [SerializeField] private AudioClip off;
        [SerializeField] private AudioSource audioSource;

        public static Audio Play = null;
        private void Awake()
        {
            if (Play != null)
            {
                throw new System.Exception();
            }
            Play = this;
        }

        public void Click()
        {
            audioSource.clip = click;
            audioSource.pitch = Random.Range(0.875f, 1.125f);
            audioSource.Play();
        }
        public void Click(bool isOn)
        {
            Debug.Log(isOn);
            audioSource.clip = isOn ? on : off;
            audioSource.pitch = Random.Range(0.875f, 1.125f);
            audioSource.Play();
        }
    }
}
