using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Selector : MonoBehaviour
{
    private PlayableCharacter _newCharacter = null;
    private CharacterData _newCharacterData = new CharacterData();

    public void CreateWarrior()
    {
        _newCharacter = new Warrior();
        _newCharacterData.SetData(_newCharacter.GetStats(), _newCharacter.GetInventory(), _newCharacter.GetClassName());

        string json = JsonUtility.ToJson(_newCharacterData);

        File.WriteAllText(Application.dataPath + "/characterFile.json", json);

        CharacterCreator.GetInstance().SetClass(_newCharacter);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreateSorcerer()
    {
        _newCharacter = new Sorcerer();
        _newCharacterData.SetData(_newCharacter.GetStats(), _newCharacter.GetInventory(), _newCharacter.GetClassName());

        string json = JsonUtility.ToJson(_newCharacterData);

        File.WriteAllText(Application.dataPath + "/characterFile.json", json);

        CharacterCreator.GetInstance().SetClass(_newCharacter);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreateRogue()
    {
        _newCharacter = new Rogue();
        _newCharacterData.SetData(_newCharacter.GetStats(), _newCharacter.GetInventory(), _newCharacter.GetClassName());

        string json = JsonUtility.ToJson(_newCharacterData);

        File.WriteAllText(Application.dataPath + "/characterFile.json", json);

        CharacterCreator.GetInstance().SetClass(_newCharacter);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
