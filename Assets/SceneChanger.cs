using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Animator animator;
    void loadScene(){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    private void OnTriggerEnter(Collider other) {
        animator.SetBool("FadeOut", true);
        StartCoroutine(sceneAfterTime());
    }

    IEnumerator sceneAfterTime(){
        yield return new WaitForSeconds(3);
        animator.SetBool("FadeOut", false);
        loadScene(); 
    }
}
