using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    public PhotonView photonView;
    public Text UpdatedText;

    private InputField ChatInputField;
    private bool DisableSend;

    private void Awake()
    {
        ChatInputField = GameObject.Find("ChatInputField").GetComponent<InputField>();
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            if(!DisableSend && ChatInputField.isFocused)
            {
                if (ChatInputField.text != "" && ChatInputField.text.Length > 0 && Input.GetKeyDown(KeyCode.Return))
                {
                    photonView.RPC("SendMessage", PhotonTargets.AllBuffered, ChatInputField.text);
                    ChatInputField.text = "";
                    DisableSend = true;
                }
            }
        }
    }

    [PunRPC]
    private void SendMessage(string message)
    {
        UpdatedText.text = message;
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(4f);
        DisableSend = false;
    }

}
