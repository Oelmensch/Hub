using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    Animator anim;
    private int fadeParamID;

    void Start()
    {
        anim = GetComponent<Animator>();

        fadeParamID = Animator.StringToHash("Fade");

        GameManager.RegisterSceneFader(this);
    }

    public void FadeSceneOut()
    {
        anim.SetTrigger(fadeParamID);
    }
}
