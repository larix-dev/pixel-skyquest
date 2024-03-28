using System.Collections.Generic;
using System.Linq;
using Handlers;

namespace Objectives {
public class MultiPillarObjective : Objective {
    private List<RunePillar> _pillars;

    private readonly List<RunePillar> _activated = new();

    private void Start() {
        _pillars = GetComponentsInChildren<RunePillar>().ToList();
        foreach (var pillar in _pillars) {
            pillar.OnPillarActivate += HandlePillarActivate;
        }
    }

    private void HandlePillarActivate(RunePillar sender) {
        _activated.Add(sender);
        if (_activated.Count != _pillars.Count) return;
        if (_activated.SequenceEqual(_pillars)) {
            SetComplete();
        } else {
            _activated.Clear();
            foreach (var pillar in _pillars) {
                pillar.SetActive(false);
            }
        }
    }
}
}