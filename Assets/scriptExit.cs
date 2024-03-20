using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptExit : MonoBehaviour
{
    public void ReturnToGame() {
        SceneManager.LoadScene("GameScene");

    }
}
