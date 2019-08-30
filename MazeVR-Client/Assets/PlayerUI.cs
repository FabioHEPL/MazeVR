using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MazeVR.Shared;

namespace MazeVR.Client
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField]
        private ClientNetworkGame game;

        [SerializeField]
        private Text endGame;

        [SerializeField]
        private Text gameStatus;

        private void Awake()
        {
            this.game = GameObject.FindObjectOfType<ClientNetworkGame>();
        }

        private void OnEnable()
        {
            this.game.Connected += Game_Connected;
            this.game.Started += Game_Started;
            this.game.Ended += Game_Ended;
        }

        private void OnDisable()
        {
            this.game.Connected -= Game_Connected;
            this.game.Started -= Game_Started;
            this.game.Ended -= Game_Ended;
        }

        private void Game_Connected()
        {
            gameStatus.text = "Connected to server.\nGame is about to start...";
        }

        private void Game_Started(object sender, StartedArgs args)
        {
            gameStatus.transform.parent.gameObject.SetActive(false);
        }


        private void Game_Ended(object sender, EndedArgs args)
        {
            // Afficher texte
            endGame.transform.parent.gameObject.SetActive(true);

            if (args.EndGame == EndGame.Victory)
            {
                endGame.text = "You win !";
            }
            else if (args.EndGame == EndGame.Defeat)
            {
                endGame.text = "You lose !";
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}