using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class OpeningSceneManager : MonoBehaviour
{
    [SerializeField] List<Image> Bubbles = new List<Image>();
    public int bubbleNum = 0;
    [SerializeField] float BubbleInterval = 1.5f;
    float startTime;
    [SerializeField] PlayableDirector President;
    [SerializeField] PlayableDirector Square;
    [SerializeField] PlayableDirector GiantBook;
    [SerializeField] PlayableDirector DumpsterAndrew;
    [SerializeField] List<PlayableDirector> Explosions = new List<PlayableDirector>();
    float timeUntilPresidentDead;
    bool startTimeUntilPresidentDead;
    [SerializeField] RawImage FadeOut;
    [SerializeField] PlayableDirector mainCamera;
    [SerializeField] AudioSource musicPlayer;
    //[SerializeField] List<GameObject> Bullets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {   
        foreach (Image bubble in Bubbles)
        {
            bubble.gameObject.SetActive(false);
        }
        bubbleNum = 0;
        Bubbles[0].gameObject.SetActive(true);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > BubbleInterval)
        {
            NextBubble();
            startTime = Time.time;
        }
        if (startTimeUntilPresidentDead && (Time.time - timeUntilPresidentDead > 2.3f))
        {
            President.gameObject.SetActive(false);
            startTimeUntilPresidentDead = false;
        }
    }

    public void NextBubble()
    {
        bubbleNum++;
            if(bubbleNum == 3)
            {
                President.Play();
            }
            if(bubbleNum == 5)
            {
                Square.Play();
                foreach(PlayableDirector playable in Explosions)
                {
                    playable.Play();
                playable.GetComponent<AudioSource>().Play();
                }
            }
            if(bubbleNum == 7)
            {
                GiantBook.Play();
            timeUntilPresidentDead = Time.time;
            startTimeUntilPresidentDead = true;
            }
            if(bubbleNum == 9)
        {
            musicPlayer.Play();
        }
            if (bubbleNum == 11)
            {
                DumpsterAndrew.Play();
                
            }
            if(bubbleNum == 19)
        {
            mainCamera.Play();
        }
            if(bubbleNum == 20)
            {
            FadeOut.GetComponent<PlayableDirector>().Play();
            }
            if(bubbleNum == 21)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ToGameScene();
        }

        if (bubbleNum != 0)
            {
                Bubbles[bubbleNum - 1].gameObject.SetActive(false);
            }
            Bubbles[bubbleNum].gameObject.SetActive(true);
        
    }
}
