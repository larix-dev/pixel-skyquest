using System.Collections;
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
        StartCoroutine(CompleteRoutine());
    }

    private IEnumerator CompleteRoutine() {
        yield return new WaitForSeconds(2f);
        result.Invoke();
    }

    protected void SetIncomplete() {
        Complete = false;
    }
}
}