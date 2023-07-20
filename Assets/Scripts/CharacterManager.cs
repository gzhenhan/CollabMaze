using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class CharacterManager : MonoBehaviour
{   
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    SerialPort data_stream = new SerialPort("COM3", 19200);
    
    public string receivedString;
    public GameObject test_data;

    public Button backButton;
    public Button nextButton;
    public Button startButton;

    void Start()
    {   
        data_stream.Open();
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else{
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    void Update(){
        receivedString = data_stream.ReadLine();
        string[] datas = receivedString.Split(',');
        if(float.Parse(datas[0]) == 8){
            backButton.onClick.Invoke();
        }

        if(float.Parse(datas[0]) == -9){
            nextButton.onClick.Invoke();
        }

        if(float.Parse(datas[2]) == 1 && float.Parse(datas[3]) == 1){
            startButton.onClick.Invoke();
        }
    }

    public void NextOption(){
        selectedOption++;
        if(selectedOption >= characterDB.CharacterCount){
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption(){
        selectedOption--;

        if(selectedOption < 0){
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption){
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load(){
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save(){
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void ChangeScene(){
        SceneManager.LoadScene("PlayScene");
    }

}
