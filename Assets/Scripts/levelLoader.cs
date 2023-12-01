using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //

public class levelLoader : MonoBehaviour
{
    [SerializeField] string []levels;
    

    private void Start() {
        foreach(string l in levels){
            SceneManager.LoadScene(l, LoadSceneMode.Additive);
        }

        Destroy(gameObject);    //
    }
}