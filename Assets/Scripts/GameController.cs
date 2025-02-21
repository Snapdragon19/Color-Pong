using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
   public GameObject ball;
   
   public TMP_Text scoreTextLeft;
   public TMP_Text scoreTextRight;

   public Starter starter;

   private bool started = false;

    private int scoreLeft = 0;
    private int scoreRight = 0;
    private BallController ballController;
    private Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPos = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.started) return;
        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            //this.ballController.Go();
            this.starter.StartCountDown();
        }
    }
    public void StartGame() 
    {
        this.ballController.Go();
    }
    public void ScoreGoalLeft() {
       Debug.Log("Score Goal Left");
       this.scoreRight += 1;
       UpdateUI();
       ResetBall();
    }
    public void ScoreGoalRight() {
       Debug.Log("Score Goal Right");
       this.scoreLeft += 1;
       UpdateUI();
       ResetBall();
    }
    private void UpdateUI() {
      this.scoreTextLeft.text = this.scoreLeft.ToString();
      this.scoreTextRight.text = this.scoreRight.ToString();
    }
    private void ResetBall() {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPos;
        //this.ballController.Go();
        this.starter.StartCountDown();
    }
}
