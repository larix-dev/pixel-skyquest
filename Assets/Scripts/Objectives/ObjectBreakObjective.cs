using Handlers;

namespace Objectives {
    public class ObjectBreakObjective : Objective {
        private void Start() {
            var hitHandler = GetComponent<ObjectBreakHandler>();
            if (hitHandler) {
                hitHandler.OnBreak += SetComplete;
            }
        }
    }
}