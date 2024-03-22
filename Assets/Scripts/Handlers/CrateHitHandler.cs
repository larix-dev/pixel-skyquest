using UnityEngine;

namespace Handlers {
public class CrateHitHandler : HitHandler {
    public GameObject drop;
    public Vector2 dropOffset;

    public override void HandleHit() {
        var go = gameObject;
        var pos = go.transform.position;
        Destroy(go);
        var result = Instantiate(drop);
        result.transform.position = pos + (Vector3)dropOffset;
    }
}
}