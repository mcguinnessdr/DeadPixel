using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Achievements : Singleton<Achievements> {

    public SaveAttributes saveAttributes;
    public string fileLocation;
    public UnityEvent fileLoaded;

	protected override void Awake () {
        base.Awake();
        fileLocation = Application.persistentDataPath + "/saveFile.dat";
        saveAttributes = new SaveAttributes();
        loadFile();
        var player = FindObjectOfType<Player>();
        if(player)
        {
            player.died.AddListener(addDeath);
        }
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
	}

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        var player = FindObjectOfType<Player>();
        if (player)
        {
            player.died.AddListener(addDeath);
        }
    }

    void addDeath()
    {
        saveAttributes.deaths++;
        if(saveAttributes.deaths == 100)
        {
            saveAttributes.oneHundredDeaths = true;
        }
    }

    void saveFile()
    {
        saveAttributes.ads = GameManager.instance.ads;
        saveAttributes.music = GameManager.instance.music;
        saveAttributes.sfx = GameManager.instance.sfx;
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(fileLocation, FileMode.Create))
        {
            formatter.Serialize(stream, saveAttributes);
        }
    }

    void loadFile()
    {
        if (!File.Exists(fileLocation))
        {
            return;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(fileLocation, FileMode.Open))
        {
            saveAttributes = formatter.Deserialize(stream) as SaveAttributes;
        }
        fileLoaded.Invoke();
    }
	
    void OnDestroy()
    {
        saveFile();
    }
}
