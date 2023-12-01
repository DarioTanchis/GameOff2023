using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    [SerializeField] GameObject mannequins;
    [SerializeField] AudioSource source;
    [SerializeField] float timeToWait = 35;

    private void Awake()
    {
        StartCoroutine(endGame());
    }


    IEnumerator endGame()
    {
        yield return new WaitForSeconds(timeToWait - 5);
        mannequins.SetActive(true);
        source.Play();
        yield return new WaitForSeconds(5);
        UI_Controller.instance.GetComponent<Animator>().SetBool("FadeOut", true);
        SceneManager.LoadScene("EndGame");
    }
}
