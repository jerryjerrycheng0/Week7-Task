using System.Collections;
using UnityEngine;
using GameDevWithMarco.Singleton;

namespace GameDevWithMarco.Managers
{
    public class VfxManager : Singleton<VfxManager>
    {
        public void HitStop(float stopDuration)
        {
            StartCoroutine(HitStopCoroutine(stopDuration));
        }

        IEnumerator HitStopCoroutine(float duration)
        {
            Time.timeScale = 0;

            yield return new WaitForSecondsRealtime(duration);

            Time.timeScale = 1;
        }
    }
}
