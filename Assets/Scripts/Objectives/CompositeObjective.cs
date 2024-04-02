using System.Collections.Generic;
using System.Linq;

namespace Objectives {
public class CompositeObjective : Objective {
    private List<Objective> _objectives;
    private bool _complete;

    private void Start() {
        _objectives = GetComponentsInChildren<Objective>().ToList();
        _objectives.RemoveAt(0); // remove parent objective
        foreach (var objective in _objectives) {
            objective.OnComplete += HandleCompletion;
        }
    }

    private void HandleCompletion() {
        if (!_complete && _objectives.All(o => o.Complete)) {
            _complete = true;
            SetComplete();
        }
    }
}
}