using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class LooseConditionOfPlayer : MonoBehaviour
    {
        [SerializeField]
        private FakePlayer player;

        //[SerializeField] int lifePointCharater = 1;
        [SerializeField] GameObject playerLose;


        private void OnEnable()
        {
            player.Death += Player_Death;

            player.DealDamage(10);
        }

        private void OnDisable()
        {
            player.Death -= Player_Death;
        }

        private void Player_Death(object sender, DeathArgs e)
        {
            Debug.Log("Le joueur est mort");
            playerLose.SetActive(true);
        }
    }
}