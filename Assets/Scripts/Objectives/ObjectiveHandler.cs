using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Objectives {
public class ObjectiveHandler : MonoBehaviour {
    public GameObject altar;
    public List<Objective> objectives;
    
    private void Start() {
        foreach (var objective in objectives) {
            objective.OnComplete += HandleCompletion;
        }
    }

    private void HandleCompletion() {
        if (objectives.All(o => o.Complete)) {
            // handle completion
        }
    }
}
}