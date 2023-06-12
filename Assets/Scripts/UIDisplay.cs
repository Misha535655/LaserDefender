using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    Health health;
    public Slider healthScroll;
    [Header("Score")]
    ScoreKeeper scoreKeeper;
    public TextMeshProUGUI score;


    void Awake() {
        health = FindObjectOfType<Health>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Update() {
        UpdateHealth();
        UpdateText();
    }
    void UpdateHealth()
    {
        healthScroll.value = health.GetHelth();
    }

    void UpdateText()
    {
        score.text = scoreKeeper.GetCurrentScore() + "";
    }



}
