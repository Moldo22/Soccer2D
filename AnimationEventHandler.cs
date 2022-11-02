using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{

    #region helper_references

    [SerializeField] Ball game_ball;

    #endregion

#region init

private void Start() {
    game_ball=GameObject.FindObjectOfType<Ball>();
}

#endregion

    public void PushBall(){
        if(Vector2.Distance(game_ball.transform.position, transform.localPosition)<3){
            game_ball.getPushed((game_ball.transform.position-transform.localPosition).normalized,0.2f);
        }
    }
}
