using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Animator sceneTransitionAnim;
    [SerializeField] private float nextSceneTime;
    private void Awake()
    {
        StartCoroutine(LoadSceneStart());
    }
    public void NextScene()
    {
        StartCoroutine(LoadSceneEnd());
    }
    private IEnumerator LoadSceneEnd()
    {
        sceneTransitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(nextSceneTime);  
    }
    private IEnumerator LoadSceneStart()
    {
        sceneTransitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(nextSceneTime);
        gameObject.SetActive(false);
    }
}
