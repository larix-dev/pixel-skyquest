using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
 * Static helper methods class
 */
public static class Helpers {
    private const float PitchVar = 0.1f;

    public static GameObject FindChild(GameObject g, string name) {
        var children = g.GetComponentsInChildren<Transform>(true);
        return children.FirstOrDefault(k => k.gameObject.name == name)?.gameObject;
    }

    public static void PlayVar(AudioSource source, MonoBehaviour mono) {
        mono.StartCoroutine(PlayVarRoutine(source));
    }

    private static IEnumerator<WaitForSeconds> PlayVarRoutine(AudioSource source) {
        var pitch = source.pitch;
        source.pitch = pitch + Random.Range(-PitchVar, PitchVar);
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        source.pitch = pitch;
    }
}