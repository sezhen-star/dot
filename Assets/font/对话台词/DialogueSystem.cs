using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public Image leftCharacter;
    public Image rightCharacter;

    public string[] sentences;

    public enum SpeakerType
    {
        Left,
        Right,
        Other   // 路人或心理
    }

    public SpeakerType[] speakerType;

    private int index = 0;

    void Start()
    {
        ShowSentence();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            index++;

            if (index < sentences.Length)
            {
                ShowSentence();
            }
            else
            {
                Debug.Log("对话结束");
            }
        }
    }

    void ShowSentence()
    {
        dialogueText.text = sentences[index];

        // 先全部变暗
        leftCharacter.color = Color.gray;
        rightCharacter.color = Color.gray;

        if (speakerType[index] == SpeakerType.Left)
        {
            leftCharacter.color = Color.white;
        }
        else if (speakerType[index] == SpeakerType.Right)
        {
            rightCharacter.color = Color.white;
        }
        // Other 不做任何高亮
    }
}
