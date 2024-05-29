using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instances;

    public int MaxNumberOfAmmos = 3;
    private int _usedNumberOfAmmos;

    [SerializeField] private float _secondsToWaitBeforeDeathCheck = 3f;
    [SerializeField] private GameObject _restartScreenObject;
    [SerializeField] private GameObject _star1;
    [SerializeField] private GameObject _star2;
    [SerializeField] private GameObject _star3;

    [SerializeField] private GameObject ScoreText;

    [SerializeField] private int No_Alien;

    [SerializeField] private GameObject _WinScene;


    private List<Alien> _aliens = new List<Alien>();

    private void Awake(){
        if (instances == null){
            instances = this;
        }

        // Get number of enemies
        Alien[] aliens = FindObjectsOfType<Alien>();
        for (int i =0; i < aliens.Length; i++){
            _aliens.Add(aliens[i]);
        }
        No_Alien = aliens.Length;
    }

    #region AmmoSettings
    public void UseAmmo()
    {
        _usedNumberOfAmmos++;
    }

    public bool HasEnoughAmmos()
    {
        if (_usedNumberOfAmmos < MaxNumberOfAmmos)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region CheckAlien
    public void removeAlien(Alien alien){
        _aliens.Remove(alien);
        float percent = (float)_aliens.Count / No_Alien;
        // Debug.Log(_aliens.Count);
        if (percent < 0.9 && percent >= 0.7){
               AppearStar1();
        } else if(percent >= 0.3 && percent <= 0.5){
               AppearStar2();
        } else if (percent == 0){
            AppearStar3();
        }

        CheckForAllALiens();
    }

    private void CheckForAllALiens(){
        if (_aliens.Count == 0){
            WinGame();
        }
    }
    #endregion

    #region Win/Lose

    private void WinGame(){
        // _restartScreenObject.SetActive(true);
        _WinScene.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

    #region star
    public void AppearStar1(){
        Destroy(_star1);
    }

    public void AppearStar2(){
        Destroy(_star2);
    }

    public void AppearStar3(){
        Destroy(_star3);
    }
    #endregion
}