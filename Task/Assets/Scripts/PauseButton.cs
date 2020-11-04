using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private bool isPause = false;

    public Text textStatuse;

    private void Start()
    {
        //textStatuse = GetComponent<Text>();
    }

    public void Pause()
    {
        if (!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
            textStatuse.text = "Stop";
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
            textStatuse.text = "Start";
        }
    }
}
