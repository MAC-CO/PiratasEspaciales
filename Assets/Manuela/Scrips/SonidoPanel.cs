using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PanelSonido : MonoBehaviour
{
    [Header("PanelSonido")]
    public Slider Volumen;
    public Slider FXVolumen;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxsourse;
    public AudioClip clicksound;
    private float lastVolume;

    [Header("Panels")]
    public GameObject PanelSonidoObject;

    private void Awake()
    {
        Volumen.onValueChanged.AddListener(ChangeVolumeMaster);
        FXVolumen.onValueChanged.AddListener(ChangeVolumeFX);
    }

    public void SetMute()
    {
        mixer.GetFloat("Volumen", out lastVolume);
        if (mute.isOn)
            mixer.SetFloat("Volumen", -80);
        else
            mixer.SetFloat("Volumen", lastVolume);
    }

    public void OpenPanel(GameObject panel)
    {
        PanelSonidoObject.SetActive(false);
        panel.SetActive(true);
        PlaySoundButton();
    }

    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("Volumen", v);
    }

    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("FXVolumen", v);
    }

    public void PlaySoundButton()
    {
        fxsourse.PlayOneShot(clicksound);
    }
}
