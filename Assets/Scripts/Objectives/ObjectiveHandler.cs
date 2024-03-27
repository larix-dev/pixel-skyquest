using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Objectives {
public class ObjectiveHandler : MonoBehaviour {
    
    public GameObject altar;
    public List<Objective> objectives;
    
    private void Update() {
        if (objectives.All(o => o.Complete())) {
            Debug.Log("All objectives complete!");
        }
    }
}
}