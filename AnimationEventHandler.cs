using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{

    #region helper_references
    [SerializeField] private Ball game_ball;
    private Ball2 game_ball2;
    private Vector2 Ghost1;
    private Vector2 Ghost2;
    private Vector2 Ghost1Position;
    private Vector2 Ghost2Position;
    private Vector2 minimumScale;
    private Vector2 minimumScale2;
    #endregion

    #region init

private void Start() {
    game_ball=GameObject.FindObjectOfType<Ball>();
    game_ball2=GameObject.FindObjectOfType<Ball2>();
}


private void FixedUpdate() {
    #region Scale||Position
    Ghost1=(Vector2)GameObject.Find("Ghost1").transform.localScale;
    Ghost2=(Vector2)GameObject.Find("Ghost2").transform.localScale;
    Ghost1Position=(Vector2)GameObject.Find("Ghost1").transform.position;
    Ghost2Position=(Vector2)GameObject.Find("Ghost2").transform.position;
    #endregion
}

#endregion

    public void PushBall()
    {
    #region distanceStatement(Ball1)
        minimumScale=new Vector2(0.1f,0.1f);
        minimumScale2=new Vector2(-0.1f,0.1f);
        if (Ghost1==minimumScale || Ghost1==minimumScale2 )
        {   
            if ((Vector2.Distance(game_ball.transform.position, Ghost1Position)<1.5)) game_ball.getPushed(((Vector2)game_ball.transform.position-Ghost1Position).normalized,0.2f);
            if ((Vector2.Distance(game_ball.transform.position, Ghost2Position)<3)) game_ball.getPushed((((Vector2)game_ball.transform.position)-Ghost2Position).normalized,0.6f);
        }
        if (Ghost2==minimumScale || Ghost2==minimumScale2)
        {
            if ((Vector2.Distance(game_ball.transform.position, Ghost1Position)<3))  game_ball.getPushed(((Vector2)game_ball.transform.position-Ghost1Position).normalized,0.6f);
            if ((Vector2.Distance(game_ball.transform.position, Ghost2Position)<1.5f)) game_ball.getPushed(((Vector2)game_ball.transform.position-Ghost2Position).normalized,0.2f);
        }
        if (Ghost1==Ghost2 || Ghost1.x==-(Ghost2.x)) if(Vector2.Distance(game_ball.transform.position, transform.localPosition)<3) game_ball.getPushed((game_ball.transform.position-transform.localPosition).normalized,0.2f);
#endregion

    #region distanceStatement(Ball2)
        minimumScale=new Vector2(0.1f,0.1f);
        minimumScale2=new Vector2(-0.1f,0.1f);
        if (Ghost1==minimumScale || Ghost1==minimumScale2 )
        {   
            if ((Vector2.Distance(game_ball2.transform.position, Ghost1Position)<1.5)) game_ball2.getPushed(((Vector2)game_ball2.transform.position-Ghost1Position).normalized,0.2f);
            if ((Vector2.Distance(game_ball2.transform.position, Ghost2Position)<3)) game_ball2.getPushed((((Vector2)game_ball2.transform.position)-Ghost2Position).normalized,0.6f);
        }
        if (Ghost2==minimumScale || Ghost2==minimumScale2)
        {
            if ((Vector2.Distance(game_ball2.transform.position, Ghost1Position)<3))  game_ball2.getPushed(((Vector2)game_ball2.transform.position-Ghost1Position).normalized,0.6f);
            if ((Vector2.Distance(game_ball2.transform.position, Ghost2Position)<1.5f)) game_ball2.getPushed(((Vector2)game_ball2.transform.position-Ghost2Position).normalized,0.2f);
        }
        if (Ghost1==Ghost2 || Ghost1.x==-(Ghost2.x)) if(Vector2.Distance(game_ball2.transform.position, transform.localPosition)<3) game_ball2.getPushed((game_ball2.transform.position-transform.localPosition).normalized,0.6f);
#endregion
    }
}
