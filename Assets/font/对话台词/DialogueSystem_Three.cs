using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem_Three : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public Image characterA;
    public Image characterB;
    public Image characterC;

    public string[] sentences;

    // 0 = A 说话
    // 1 = B 说话
    // 2 = C 说话
    // 3 = 无人（心理或旁白）
    public int[] speaker;

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
        characterA.color = new Color(0.6f, 0.6f, 0.6f, 1f);
        characterB.color = new Color(0.6f, 0.6f, 0.6f, 1f);
        characterC.color = new Color(0.6f, 0.6f, 0.6f, 1f);

        // 根据 speaker 高亮
        if (speaker[index] == 0)
        {
            characterA.color = Color.white;
        }
        else if (speaker[index] == 1)
        {
            characterB.color = Color.white;
        }
        else if (speaker[index] == 2)
        {
            characterC.color = Color.white;
        }
        // 3 就不亮任何人
    }
}
