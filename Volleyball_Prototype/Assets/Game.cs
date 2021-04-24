using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game : MonoBehaviour, Controls.IPlayerActions
{
    public GameObject BallPrefab;



    public void SpawnBall()
    {
        Player.player.Ball = Instantiate(BallPrefab, Player.player.transform.position, Quaternion.identity);
    }


    public void OnSpawnBall(InputAction.CallbackContext context)
    {
        if(context.started)
            SpawnBall();
    }
    public void OnHit(InputAction.CallbackContext context) => throw new System.NotImplementedException();

    public void OnJump(InputAction.CallbackContext context) => throw new System.NotImplementedException();

    public void OnLook(InputAction.CallbackContext context) => throw new System.NotImplementedException();

    public void OnMove(InputAction.CallbackContext context) => throw new System.NotImplementedException();

    public void OnPickup(InputAction.CallbackContext context) => throw new System.NotImplementedException();

    public void OnToss(InputAction.CallbackContext context) => throw new System.NotImplementedException();
}
