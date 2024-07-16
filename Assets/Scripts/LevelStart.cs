using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelStart : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private int _countSeconds;

    [SerializeField] private Objects _objectsClass;

    private void Start()
    {
        _startButton.onClick.AddListener(ButtonLevelStart);
    }
    private void ButtonLevelStart()
    {
        HolesShuffle();
        StartCoroutine(_objectsClass.ObjectsCreation());
        StartCoroutine(LevelTimer());  
        _startButton.gameObject.SetActive(false);
        
    }
    public IEnumerator LevelTimer()
    {
        for (int i = _countSeconds; i > 0 ; i--)
        {
            _timerText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        EndGame();
    }

    private void EndGame()
    {
        _startButton.gameObject.SetActive(true);
        _timerText.text = "0";
        _objectsClass.IsCreate = false;
    }
    private void HolesShuffle()
    {
        System.Random random = new System.Random();
        for (int i = _objectsClass.Holes.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            var temp = _objectsClass.Holes[j];
            _objectsClass.Holes[j] = _objectsClass.Holes[i];
            _objectsClass.Holes[i] = temp;
        }
    }
}

    
