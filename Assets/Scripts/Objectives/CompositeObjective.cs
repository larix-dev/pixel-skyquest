using System.Collections.Generic;
using System.Linq;

namespace Objectives {
public class CompositeObjective : Objective {
    private List<Objective> _objectives;

    private void Start() {
        _objectives = GetComponentsInChildren<Objective>().ToList();
        _objectives.RemoveAt(0); // remove parent objective
        foreach (var objective in _objectives) {
            objective.OnComplete += HandleCompletion;
        }
    }

    private void HandleCompletion() {
        if (_objectives.All(o => o.Complete)) {
            SetComplete();
        }
    }
}
}