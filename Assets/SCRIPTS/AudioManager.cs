using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource MusicSource;
    [SerializeField]private Slider sliderVolume;

    private void Awake()
    {
        MusicSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarVolumen()
    {
        MusicSource.volume = sliderVolume.value;
    }
}
