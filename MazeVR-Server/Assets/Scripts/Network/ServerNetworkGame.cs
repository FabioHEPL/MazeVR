using MazeVR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Server
{
    public class ServerNetworkGame : NetworkBehaviour
    {
        [SerializeField]
        private MazeVRServerNetwork serverNetwork;

        [SerializeField]
        private LoseCondition loseCondition;

        [SerializeField]
        private WinCondition winCondition;


        public event Action Connected;
        public event Action Started;

        private void Awake()
        {
            this.serverNetwork = FindObjectOfType<MazeVRServerNetwork>();
            this.loseCondition = FindObjectOfType<LoseCondition>();
            this.winCondition = FindObjectOfType<WinCondition>();
        }

        private void OnEnable()
        {
            serverNetwork.Ready += ServerNetwork_Ready;
            loseCondition.Fulfilled += LoseCondition_Fulfilled;
            winCondition.Fulfilled += WinCondition_Fulfilled;
        } 

        private void OnDisable()
        {
            serverNetwork.Ready -= ServerNetwork_Ready;
            loseCondition.Fulfilled -= LoseCondition_Fulfilled;
            winCondition.Fulfilled -= WinCondition_Fulfilled;
            // game.Ended -= Game_Ended;
        }

        private void ServerNetwork_Ready()
        {
            OnConnected();
            OnStarted();
        }

        private void OnConnected()
        {
            NetworkBehaviourUpdatedArgs args = new NetworkBehaviourUpdatedArgs("Connected");
            OnUpdated(args);

            this.Connected?.Invoke();
        }

        private void OnStarted()
        {
            NetworkBehaviourUpdatedArgs args = new NetworkBehaviourUpdatedArgs("Started");
            OnUpdated(args);

            this.Started?.Invoke();
        }

        private void LoseCondition_Fulfilled(object sender, FulfilledArgs e)
        {
            OnGameEnded(this, new ServerGame.EndedArgs());
        }

        private void WinCondition_Fulfilled(object sender, FulfilledArgs e)
        {
            OnGameEnded(this, new ServerGame.EndedArgs());
        }

        private void OnGameEnded(object sender, ServerGame.EndedArgs e)
        {
            // TODO:
            // regarder si le jeu s'est terminé en defaite ou victoire pour le joueur
            // 0 : defaite, 1 : victoire
            NetworkBehaviourUpdatedArgs args = new NetworkBehaviourUpdatedArgs("Ended", 0);

            OnUpdated(args);
        }

        public override void Synchronize(OscMessage message)
        {

        } 
    }
}
