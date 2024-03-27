using UnityEngine;
using UnityEngine.Events;

namespace Objectives {
public abstract class Objective : MonoBehaviour {
    public UnityEvent result;

    public delegate void CompleteAction();

    public event CompleteAction OnComplete;

    public bool Complete { get; private set; }

    protected void SetComplete() {
        Complete = true;
        OnComplete?.Invoke();
        result.Invoke();
    }

    protected void SetIncomplete() {
        Complete = false;
    }
}
}