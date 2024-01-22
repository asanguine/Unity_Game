using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour {
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private int maxHearts = 3;
    private int currentHearts;

    void Start() {
        currentHearts = maxHearts;
        UpdateHeartsUI();
    }

    public void UpdateHeartsUI() {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < currentHearts)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    public void LoseHeart() {
        if (currentHearts > 0) {
            currentHearts--;
            UpdateHeartsUI();
        }
    }

    public void GainHeart() {
        if (currentHearts < maxHearts) {
            currentHearts++;
            UpdateHeartsUI();
        }
    }
}
