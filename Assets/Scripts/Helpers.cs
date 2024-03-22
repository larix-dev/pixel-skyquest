using System.Linq;
using UnityEngine;

/**
 * Static helper methods class
 */
public static class Helpers {
    
    public static GameObject FindChild(GameObject g, string name) {
        var children = g.GetComponentsInChildren<Transform>();
        return children.FirstOrDefault(k => k.gameObject.name == name)?.gameObject;
    }
}