using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] AudioClip []audioClips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float maxPitchChange = .2f;
    [SerializeField] float stepsInterval = .5f;

    private void Awake()
    {
    }

    float lastStepTime;
    int toPlay;
    // Update is called once per frame
    void Update()
    {
        if(cc.velocity.magnitude > .2f && audioClips.Length > 0 && Time.time - lastStepTime > stepsInterval)
        {
            toPlay = Random.Range(0, audioClips.Length);

            audioSource.pitch = Random.Range(1 - maxPitchChange, 1 + maxPitchChange);
            audioSource.PlayOneShot(audioClips[toPlay]);

            lastStepTime = Time.time;
        }        
    }
}
