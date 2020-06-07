using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip crack;
    public GameObject smoke;

    private bool isBreakable;
	private LevelManager levelManager;
	private int timesHit;

	// Use this for initialization
	void Start () {

        isBreakable = this.tag == "Breakable";

        if (isBreakable)
            breakableCount++;

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

	}

	void OnCollisionEnter2D(Collision2D col){

        AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable)
			HandleHits ();

	}

	void HandleHits(){

		timesHit++;
		int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
         
            breakableCount--;
            Destroy(gameObject);
            levelManager.BrickDestroyed();
            PuffSmoke();

            print(breakableCount);

        }
        else
            LoadSprites();
		
	}

    void PuffSmoke()
    {

        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);

        ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;

    }

	void LoadSprites(){

		int spriteIndex = timesHit - 1;

		if(hitSprites[spriteIndex] != null)
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];

	}

	//TODO: remove this method once we can actually win
	void SimulateWin(){
		levelManager.LoadNextLevel ();
	}

}
