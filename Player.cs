using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random=System.Random;

public class Player : MonoBehaviour
{
#region Inputs    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator player;
    [SerializeField] private Vector2 lastPosition;
    [SerializeField] private Text Score;
    [SerializeField] private Text Timer;
    [SerializeField] private Text Result;
    [SerializeField] private float speed = 6;
    [SerializeField] private float jumpForce = 30000f;
    [SerializeField] private bool player1; 
    private GameObject panel;
    private GameObject GOPanel;
    private GameObject ball;
    private GameObject ball2;
    private Vector2 FBall; 
    private Vector2 FBall2;
    private bool onGround=true;
    private bool RegisteredGoal=false;
    private bool modifyRange=false;
    private static bool level2=false;
    public static bool NormalMode=false;
    public static bool NextLevel=false;
    private static bool displayBall2=false;
    private int player1C=0;
    private int player2C=0;
    private int Rescale;
    private int modCharacter;
    private float currentTime;
    private float startingTime=60f;
    
#endregion

    #region PlayerCollision
     void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.tag=="Teren") onGround=true; 
    }

    private  void OnCollisionExit2D(Collision2D col2)
    {
        if (col2.gameObject.tag=="Teren") onGround=false;
    }
#endregion
  
private void UpdateScore()
{
    #region ScoreUpdating
         Score.text = player1C.ToString()+" : "+player2C.ToString();  
         if ((modifyRange==false) && (Rescale==(player1C+player2C)))  //Super Powers mode
         {
            modifyRange=true;
            Random rd=new Random();
            modCharacter=rd.Next(1,3);
         }  
        else if(Rescale!=(player1C+player2C))  //Return statement to initial settings
        {
            modifyRange=false;
            modCharacter=0;
        }
    #endregion
}
private void Reset() 
{
    Vector2 reset, reset2;
    reset=new Vector2(-7.8f,0.6f);
    reset2=new Vector2(7.8f,0.6f);
    if (rb.name=="Ghost1") rb.position= reset;
    if (rb.name=="Ghost2") 
    {
        rb.position= reset2;
        rb.transform.localScale=new Vector2(-0.4f,0.4f);
    }
    ball=GameObject.Find("Ball");
    ball.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
    ball.GetComponent<Rigidbody2D>().angularVelocity = 0; 
    ball.transform.position=new Vector2(0,-0.2f);
    ball2.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
    ball2.GetComponent<Rigidbody2D>().angularVelocity = 0; 
    ball2.transform.position=new Vector2(0,-0.2f);    
}

    #region Init  
    void Start()
    {
        #region Ball2 MeshRender
        ball2=GameObject.Find("Ball2");
        ball2.GetComponent<MeshRenderer>();
        #endregion   

        panel=GameObject.Find("Canvas/LevelPanel");
        GOPanel=GameObject.Find("Canvas/GameOverPanel");
       #region StartingMode
        if(!NormalMode)
        {
            Random rd=new Random();
            Rescale=rd.Next(1,4);
        }
        else Rescale=-1;
        #endregion

        rb = GetComponent<Rigidbody2D>();
        if(transform.name=="Ghost1")
            player1=true;
            else
            player1=false; 
        UpdateScore();
        if (!NextLevel) currentTime=startingTime;
        else currentTime=100; //Setting the level timer
    }
#endregion
    private void FixedUpdate() 
    {

    #region global
            
        if (Input.GetAxisRaw("Vertical")==0)
        {   
            player.SetFloat("Movement",Vector2.Distance((Vector2)transform.position,lastPosition)/Time.fixedDeltaTime);
            lastPosition=transform.position;
        }
#endregion

    #region TimeCounter
        currentTime -= 1 * Time.fixedDeltaTime; 
        Timer.text=((int)currentTime+ " seconds");
        if (currentTime<1 && (player1C==player2C)) Timer.text=("golden goal");
        if(currentTime<1 && player1C>player2C) 
        {
            Result.text=("Winner: Ghost1");
            panel.SetActive(true);
        }
        else if (currentTime<1 && player1C<player2C) 
        {
            Result.text=("Winner Ghost2");
            panel.SetActive(true);
        }
        #endregion

    #region GoalChecking
        if ((FBall.x<(-9.2f) || FBall.x>9.2f) || (FBall2.x<(-9.2f) || (FBall2.x>9.2)))
        {
            RegisteredGoal=false;
            if (!RegisteredGoal)
            {
                if (FBall.x<(-9.2f) && FBall.y<1.21f) player2C=player2C+1;
                if (FBall.x>9.2f && FBall.y<1.21f ) player1C=player1C+1;
                Reset();
                RegisteredGoal=true;
                UpdateScore();
            }
        }
#endregion

    #region NextLevel
        if (NextLevel)
        {
            Reset();
            player1C=player2C=0;
            UpdateScore();
            displayBall2=true;
            ball2.SetActive(true);
            NextLevel = false;
            level2=true;
        }
    #endregion 

    }

    private void Update()
    {

    #region Visibility
    if (displayBall2 && currentTime<1) GOPanel.SetActive(true);
    else GOPanel.SetActive(false);
    if (displayBall2)
       { 
         panel.SetActive(false);
       }
    else if (currentTime>1) panel.SetActive(false);    
    if (!displayBall2) ball2.SetActive(false);
    #endregion

    #region Ball_Position        
         FBall=(Vector2)GameObject.Find("Ball").transform.position;
         try{
            FBall2=(Vector2)GameObject.Find("Ball2").transform.position;
         }catch(NullReferenceException){};
#endregion

    #region Player1Input
        if (player1)
        {
            if (Input.GetKey(KeyCode.S)) player.SetBool("SpacePressed",true);
            else player.SetBool("SpacePressed",false);
            if ((Input.GetKeyDown(KeyCode.W)) && onGround==true)
            {
                rb.AddForce((Vector2.up*jumpForce*Time.fixedDeltaTime),ForceMode2D.Force);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity=transform.right*-1*speed;
                //playerScale
                if (modifyRange && modCharacter==1) transform.localScale=new Vector2(-0.1f,0.1f);
                else transform.localScale=new Vector2(-0.4f,0.4f);
                //
            }
            else if(Input.GetKey(KeyCode.D))
            {
                rb.velocity=transform.right*speed;
                //playerScale
                if(modifyRange && modCharacter==1) transform.localScale=new Vector2(0.1f,0.1f);
                else transform.localScale=new Vector2(0.4f,0.4f);
                //
            }
        }   
#endregion

    #region Player2Input
    if (!player1)
    {
        if (Input.GetKey(KeyCode.DownArrow)) player.SetBool("spacePressed2",true);
        else player.SetBool("spacePressed2",false);
        if ((Input.GetKeyDown(KeyCode.UpArrow)) && onGround==true)
        {
            rb.AddForce(Vector2.up*jumpForce*Time.fixedDeltaTime,ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity=transform.right*-1*speed;
            //playerScale
            if (modifyRange && modCharacter==2) transform.localScale=new Vector2(-0.1f,0.1f);
            else transform.localScale=new Vector2(-0.4f,0.4f);
            //
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity=transform.right*speed;
            //playerScale
            if(modifyRange && modCharacter==2) transform.localScale=new Vector2(0.1f,0.1f);
            else transform.localScale=new Vector2(0.4f,0.4f);
            //
        }
        
    }
#endregion    
    }
}
