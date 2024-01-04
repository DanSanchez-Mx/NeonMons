using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void BackToMenu() {          SceneManager.LoadScene("Menu");                     }

    public void CharacterSelect() {     SceneManager.LoadScene("CharacterSelect");          }

    public void Gameplay() {            SceneManager.LoadScene("SampleScene");              }
}
