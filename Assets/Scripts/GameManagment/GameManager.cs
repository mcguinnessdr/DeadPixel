using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : Singleton<GameManager> {

    public enum Setting { ads, music, sfx}
    public bool mobileControls;
    public bool ads;
    public bool music;
    public bool sfx;
    public Pause pause;
	void Start () {
        mobileControls = Application.platform == RuntimePlatform.Android;
        music = Achievements.instance.saveAttributes.music;
        ads = Achievements.instance.saveAttributes.ads;
        sfx = Achievements.instance.saveAttributes.sfx;
        pause = GetComponent<Pause>();
        print("sending custom event");
        Analytics.CustomEvent("Started Game", new Dictionary<string, object>
        {
            { "Ads", ads },
            {"Music", music },
            {"sfx", sfx }
         });
    }

    public bool ToggleSetting(Setting setting)
    {
        print("toggle setting");
        switch (setting)
        {
            case Setting.ads:
                return Toggle(ref ads);
            case Setting.music:
                return Toggle(ref music);
            case Setting.sfx:
                return Toggle(ref sfx);
        }
        return false;
    }

    public bool SetSetting(Setting setting, bool value)
    {
        switch (setting)
        {
            case Setting.ads:
                ads = value;
                print("sending custom event");
                Analytics.CustomEvent("Set Ad Setting", new Dictionary<string, object>
                {
                    { "Ads", ads }
                });
                return ads;
            case Setting.music:
                music = value;
                return music;
            case Setting.sfx:
                sfx = value;
                return sfx;
        }
        return false;
    }

    public bool GetSetting(Setting setting)
    {
        switch (setting)
        {
            case Setting.ads:
                return ads;
            case Setting.music:
                return music;
            case Setting.sfx:
                return sfx;
        }
        return false;
    }

    bool Toggle(ref bool setting)
    {
        setting = !setting;
        return setting;
    }
}
