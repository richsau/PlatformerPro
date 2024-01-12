using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _collectedAllAudioClip;
    private int _score = 0;
    private float _currentTime = 0f;
    private UIManager _uiManager;
    private bool _gameRunning = false;
    private AudioSource _audioSource;



    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("Could not find UIManager in GameManager.");
        }
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("Could not find AudioSource in GameManager.");
        }


        //_uiManager.UpdateScore(_score);
        _score = 0;
        _gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameRunning == true)
        {
            _currentTime += Time.deltaTime;
            _uiManager.UpdateTime(_currentTime.ToString("0.0"));
            _uiManager.UpdateScore(_score.ToString() + "/10");
        } 
    }

    public void AddScore()
    {
        _score++;
        if (_score >= 10)
        {
            _audioSource.clip = _collectedAllAudioClip;
            _audioSource.Play();
        }
        //_uiManager.UpdateScore(_score);
    }

}
