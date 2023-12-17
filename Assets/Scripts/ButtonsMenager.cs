using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsMenager : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] Animator _kyleAnimator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _panel.SetActive(true);
        }
    }


    public void Click_Play()
    {
        _panel.SetActive(false);
        _kyleAnimator.SetBool("idle", true);
    }
}
