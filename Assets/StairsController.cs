using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider nextSceneCollider;
    [SerializeField] BoxCollider blockStairsCollider;

    private void Start()
    {
        blockStairsCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            blockStairsCollider.enabled = true;
            animator.SetBool("Aperta", false);
        }

    }

    public void openStairs(bool open)
    {
        animator.SetBool("Aperta", open);
    }

    public int getSceneIndex()
    {
        return gameObject.scene.buildIndex;
    }
}
