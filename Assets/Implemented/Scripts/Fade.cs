using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Animator animator;
    [SerializeField] float  startFade;
    [SerializeField] float fadeTimer;
    void Start()
    {
        animator = GetComponent<Animator>();
        startFade = Ghosting.instance.ghostDelay* Ghosting.instance.numOfGhosts -1;
    }

    // Update is called once per frame
    void Update()
    {
        fadeTimer += Time.deltaTime;
        if(fadeTimer >= startFade){
            animator.SetTrigger("Fade");
        }
    }
}
