using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScene : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    private void Start()
    {
        StartCoroutine(MakeTransition());
    }

    private IEnumerator MakeTransition()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainScene");
    }
}
