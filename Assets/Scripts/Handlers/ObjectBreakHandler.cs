using UnityEngine;

namespace Handlers {
public class ObjectBreakHandler : HitHandler {
    public GameObject drop;
    public Vector2 dropOffset;

    public delegate void BreakAction();
    public event BreakAction OnBreak;

    public override void HandleHit() {
        var go = gameObject;
        var pos = go.transform.position;
        OnBreak?.Invoke();
        Destroy(go);
        var result = Instantiate(drop);
        result.transform.position = pos + (Vector3)dropOffset;
    }
    
}
}