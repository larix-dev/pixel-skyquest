using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public Animator anim;

    private static readonly int FadeOut = Animator.StringToHash("FadeOut");
    private const float Duration = 2f;

    private AudioSource _bgm;

    private void Start() {
        _bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    public void LoadScene(string scene) {
        StartCoroutine(FadeMusicRoutine());
        StartCoroutine(LoadSceneRoutine(scene));
    }

    private IEnumerator LoadSceneRoutine(string scene) {
        anim.SetTrigger(FadeOut);
        yield return new WaitForSeconds(Duration);
        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeMusicRoutine() {
        var startVol = _bgm.volume;
        var timer = 0f;
        while (timer < Duration) {
            timer += Time.deltaTime;
            _bgm.volume = Mathf.Lerp(startVol, 0f, timer / Duration);
            yield return null;
        }

        _bgm.volume = 0f;
    }
}