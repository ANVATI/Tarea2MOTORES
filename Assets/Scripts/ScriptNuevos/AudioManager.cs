using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSFX;
    [SerializeField] private Image soundButtonImage; // Referencia al componente Image del botón de silencio
    public Sprite soundOnSprite; // Sprite cuando el sonido está activado
    public Sprite soundOffSprite; // Sprite cuando el sonido está silenciado
    [SerializeField] private AudioSettings audioSettings;
    private bool IsSilenced;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        IsSilenced = false; // Inicialmente el sonido no está silenciado
        LoadVolumeSettings();
    }

    private void LoadVolumeSettings()
    {
        sliderMaster.value = audioSettings.masterVolume;
        sliderMusic.value = audioSettings.musicVolume;
        sliderSFX.value = audioSettings.sfxVolume;
        SetVolumeMaster();
        SetVolumeMusic();
        SetVolumeSFX();
    }

    public void SetVolumeMaster()
    {
        if (!IsSilenced)
        {
            float volume = sliderMaster.value;
            myMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
            audioSettings.masterVolume = volume;
        }
    }

    public void SetVolumeMusic()
    {
        if (!IsSilenced)
        {
            float volume = sliderMusic.value;
            myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
            audioSettings.musicVolume = volume;
        }
    }

    public void SetVolumeSFX()
    {
        if (!IsSilenced)
        {
            float volume = sliderSFX.value;
            myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
            audioSettings.sfxVolume= volume;
        }
    }

    public void ToggleMute()
    {
        IsSilenced = !IsSilenced;

        if (IsSilenced)
        {
            myMixer.SetFloat("Master", -80f);
            myMixer.SetFloat("music", -80f);
            myMixer.SetFloat("SFX", -80f);
        }
        else
        {

            SetVolumeMaster();
            SetVolumeMusic();
            SetVolumeSFX();
        }
    }

    public void UpdateSoundButtonSprite()
    {
        // Cambia el sprite del botón según el estado de silencio
        if (IsSilenced)
        {
            soundButtonImage.sprite = soundOffSprite; // Cambia al sprite de sonido silenciado
        }
        else
        {
            soundButtonImage.sprite = soundOnSprite; // Cambia al sprite de sonido activado
        }
    }
}