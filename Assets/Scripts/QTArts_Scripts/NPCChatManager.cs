using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QTArts.Classes
{
    public class NPCChatManager : MonoBehaviour
    {
        public enum TypeOfResponse 
        { 
            chatMessage, 
            goodResponse, 
            badResponse 
        }

        [SerializeField]
        string[] _chatMessage;

        [SerializeField]
        string[] _goodResponse, _badResponse;

        [SerializeField]
        Text _text;

        public void SelectChat(TypeOfResponse whichResponse, int messageInt)
        {
            string printMessage = "I am an error.";

            switch (whichResponse)
            {
                case TypeOfResponse.chatMessage:
                    printMessage = _chatMessage[messageInt];
                    break;

                case TypeOfResponse.goodResponse:
                    printMessage = _goodResponse[messageInt];
                    break;

                case TypeOfResponse.badResponse:
                    printMessage = _badResponse[messageInt];
                    break;
            }

            _text.text = printMessage;
        }
    }
}
