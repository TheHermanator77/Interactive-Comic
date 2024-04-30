using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{

    public TMP_Text credits;
    public Button restartButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        credits = GetComponent<TextMeshProUGUI>();
        Invoke("ArtCredits", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to show art credits
    public void ArtCredits(){
        Debug.Log("Art Credits");
        credits.text = "Art:\nYasmina Daniel\nWyatt Mullani";
        Invoke("EntanglementCredits", 5f);
    }

    //Function to Show Entanglement game credits
    public void EntanglementCredits(){
        Debug.Log("Entanglement Credits");
        credits.text = "Entanglement Minigame:\nKyle Herman";
        Invoke("TunnellingCredits", 5f);
    }

    //function to show tunnelling credits
    public void TunnellingCredits(){
        Debug.Log("Tunnelling Credits");
        credits.text = "Tunnelling Minigame:\nAlukka Ivanoff";
        Invoke("RhythmCredits", 5f);
    }

    //function to show rhythm game credits
    public void RhythmCredits(){
        Debug.Log("Rhythm Credits");
        credits.text = "Rhythm Minigame:\nTheron Lindsay";
        Invoke("AnimationCredits", 5f);
    }

    //function to show animation credits
    public void AnimationCredits(){
        Debug.Log("Animation Credits");
        credits.text = "Animation:\nKyle Herman\nWyatt Mullani";
        Invoke("ComicCredits", 5f);
    }

    //comic gui credits
    public void ComicCredits(){
        Debug.Log("Comic GUI Credits");
        credits.text = "Comic GUI:\nTheron Lindsay";
        Invoke("ClearCredits", 5f);
    }

    public void ClearCredits(){
        credits.text = "";
        Invoke("ShowMenu", 5f);
    }

    //show buttons to restart or quit
    public void ShowMenu(){
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene("ComicBook");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
