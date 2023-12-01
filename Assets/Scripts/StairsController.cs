using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider nextSceneCollider;
    [SerializeField] BoxCollider blockStairsCollider;

    GrabProps player;

    private void Start()
    {
        blockStairsCollider.enabled = false;

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (g.activeInHierarchy && g.TryGetComponent(out GrabProps grab))
            {
                player = grab;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            blockStairsCollider.enabled = true;
            animator.SetBool("Aperta", false);
            StartCoroutine(CheckCloseAnimationEnd());
        }

    }

    public void openStairs(bool open)
    {
        animator.SetBool("Aperta", open);
        player.RemoveGrabbed();
    }

    public int getSceneIndex()
    {
        return gameObject.scene.buildIndex;
    }

    IEnumerator CheckCloseAnimationEnd()
    {
        while(!animator.GetCurrentAnimatorStateInfo(0).IsName("Chiusa"))
        {
            yield return null;
        }

        float startTime = Time.time;

        Debug.Log("Si sta chiudendo");

        while (Time.time - startTime < animator.GetCurrentAnimatorClipInfo(0).Length)
        {
            yield return null;
        }

        Debug.Log("Si è chiusa");

        blockStairsCollider.gameObject.SetActive(false);
    }
}
