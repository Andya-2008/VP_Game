using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] List<PlayableDirector> Explosions = new List<PlayableDirector>();
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
    }

    public void NextBubble()
    {
        bubbleNum++;
        /*if (bubbleNum == Bubbles.Count)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ToGameScene();
        }*/
        //else
        //{
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
                }
            }
            if(bubbleNum == 7)
            {
                GiantBook.Play();
            }
            if (bubbleNum != 0)
            {
                Bubbles[bubbleNum - 1].gameObject.SetActive(false);
            }
            Bubbles[bubbleNum].gameObject.SetActive(true);
        //}
        
    }
}
