using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelSelectPanel;

    private void Awake ()
    {
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);

    }

    public void OpenPanel (GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        panel.SetActive(true);
    }

    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }
    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("VolFX", v);
    }
}
