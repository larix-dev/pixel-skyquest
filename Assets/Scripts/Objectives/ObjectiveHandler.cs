using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Objectives {
public class ObjectiveHandler : MonoBehaviour {
    public AltarTrigger altar;
    public List<Objective> objectives;

    private AudioSource _sfx;

    private void Start() {
        foreach (var objective in objectives) {
            objective.OnComplete += HandleCompletion;
        }

        _sfx = GetComponent<AudioSource>();
    }

    private void HandleCompletion() {
        _sfx.Play();
        if (objectives.All(o => o.Complete)) {
            StartCoroutine(LevelCompleteRoutine());
        }
    }

    private IEnumerator LevelCompleteRoutine() {
        yield return new WaitForSeconds(3);
        altar.TriggerAltar();
    }
}
}