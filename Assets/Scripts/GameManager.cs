
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI hpText;
    public static GameManager instance = null;

    public int score =0;
    [SerializeField]
    public int hp =2;

    void Awake(){
        if(instance == null){
            instance = this;
        }
		// else if (instance != this)  //챗지피티가 추가한 코드
		// {
		// 	Destroy(gameObject);
		// }

		// DontDestroyOnLoad(gameObject);

        hpText.SetText(hp.ToString());
    }


    public void IncreaseScore(){
        score++;
        scoreText.SetText(score.ToString());
    }

    public void DecreaseHp(){
        if(hp>=1){
            hp--;
            Debug.Log("hp 감소");
        }
        hpText.SetText(hp.ToString());
    }
    public void IncreaseHp(){
        hp++;
        Debug.Log("hp 증가");
        hpText.SetText(hp.ToString());
    }
	// public void PlayerDied() 없어도 된다.
	// {
	// 	Debug.Log("Game Over");
	// }
}
