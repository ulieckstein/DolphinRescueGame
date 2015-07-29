using System;
using Soomla.Store;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text ScoreText;
    public Canvas MoreMenu;
    public Text SoundButtonText;
    public Canvas SupporterBadge;

    void Start ()
    {
        var score = PlayerPrefs.GetInt("highscore", 0);
        if (score > 0) ScoreText.text = String.Format("Highscore: {0}", score);
        MoreMenu.enabled = false;
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        SetSoundButtonText();
        SoomlaStore.Initialize(new MarketAssets());
        if (StoreInventory.GetItemBalance("support_badge") > 0) SupporterBadge.enabled = true;
        
    }

    public void ToggleMoreMenu()
    {
        Debug.Log("Toggle MoreMenu");
        MoreMenu.enabled = !MoreMenu.enabled;
    }

    public void ToggleSound()
    {
        AudioListener.volume = Math.Abs(AudioListener.volume - 1);
        SetSoundButtonText();
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
        PlayerPrefs.Save();
    }

    private void SetSoundButtonText()
    {
        SoundButtonText.text = string.Format("Sound {0}", AudioListener.volume == 0 ? "off" : "on");
    }
}
