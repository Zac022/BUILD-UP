using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cameraControl : MonoBehaviour
{
    public Animator anim;
    public GameObject ExitButton;
    public Slider slider;

    [Range(0, 5)] [SerializeField] private  int Counter = -1;

    private readonly int movement = Animator.StringToHash("move");
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        slider.onValueChanged.AddListener(UpdateAnimeSpeed);
       
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ActualStart()
    {
        Counter++;
        AnimationRun();
    }

    private void UpdateAnimeSpeed(float value)
    {
        anim.speed = value;
    }
    

    private void AnimationRun()
    {
        anim.SetInteger(movement, Counter);
    }



    public void NextScene()
    {
        if (Counter != 4)
        {
            Counter++;
            AnimationRun();
            
        }

        if (Counter >= 4)
        {
            ExitButton.SetActive(true);
        }
        else
        {
            ExitButton.SetActive(false);
        }
    }

    public void Previous()
    {
        if (Counter != 0)
        {
            Counter--;
            AnimationRun();
        }
    }


    public void ExitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        
        Application.Quit();
    }


}
