using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MuteButton : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Image soundButtonImage; // Referencia al componente Image del botón de silencio
    public Sprite soundOnSprite; // Sprite cuando el sonido está activado
    public Sprite soundOffSprite; // Sprite cuando el sonido está silenciado
    [SerializeField] private AudioSettings audioSettings; // Referencia al ScriptableObject que almacena la configuración del audio
    private bool isSilenced;

    private void Start()
    {
        isSilenced = false;
        UpdateSoundButtonSprite();
    }

    public void ToggleMute()
    {
        isSilenced = !isSilenced;

        if (isSilenced)
        {

            myMixer.SetFloat("Master", -80f);
            myMixer.SetFloat("music", -80f);
            myMixer.SetFloat("SFX", -80f);
        }
        else
        {

            myMixer.SetFloat("Master", audioSettings.masterVolume);
            myMixer.SetFloat("music", audioSettings.musicVolume);
            myMixer.SetFloat("SFX", audioSettings.sfxVolume);
        }

        UpdateSoundButtonSprite();
    }

    private void UpdateSoundButtonSprite()
    {
        if (isSilenced)
        {
            soundButtonImage.sprite = soundOffSprite;
        }
        else
        {
            soundButtonImage.sprite = soundOnSprite;
        }
    }
}