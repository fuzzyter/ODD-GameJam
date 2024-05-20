using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    //public TextMeshProUGUI face;

    private int currentLineIndex = 0;

    void Start()
    {
        if (CSVRead.doubleChatList != null && CSVRead.doubleChatList.Length > 0)
        {
            DisplayLine();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentLineIndex < CSVRead.doubleChatList.GetLength(0) - 1)
            {
                currentLineIndex++;
                DisplayLine();
            }
        }
    }

    void DisplayLine()
    {
        string speakerName = CSVRead.doubleChatList[currentLineIndex, 1];
        string dialogueLine = CSVRead.doubleChatList[currentLineIndex, 3];

        nameText.text = speakerName;
        dialogueText.text = dialogueLine;
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

[System.Serializable]
public struct TalkData
{
    public string name;
    public string[] contexts;
}

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Speaker[] speakers;
    [SerializeField] private DialogData[] dialogs;
    private bool isAutoStart = true;
    private bool isFirst = true;
    private int currentDialogIndex = -1;
    private int currentSpeakerIndex = 0;

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        if (isFirst == true)
        {
            Setup();
            if (isAutoStart) SetNextDialog();

            isFirst = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();
            }
            else
            {
                for (int i = 0; i < speakers.Length; ++i)
                {
                    SetActiveObjects(speakers[i], false);
                    speakers[i].spriteRenderer.gameObject.SetActive(true);
                }
                return true;
            }
        }

        return false;
    }

    private void SetNextDialog()
    {
        if (currentDialogIndex >= 0)
        {
            SetActiveObjects(speakers[currentSpeakerIndex], false);
        }

        currentDialogIndex++;

        if (currentDialogIndex >= dialogs.Length)
        {
            return;
        }

        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

        SetActiveObjects(speakers[currentSpeakerIndex], true);

        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;
        speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);

        speaker.objectArrow.SetActive(false);

        Color color = speaker.spriteRenderer.color;
        color.a = visible ? 1 : 0.2f;
        speaker.spriteRenderer.color = color;
    }

    [System.Serializable]
    public struct Speaker
    {
        public SpriteRenderer spriteRenderer;
        public Image imageDialog;
        public TextMeshProUGUI textName;
        public TextMeshProUGUI textDialogue;
        public GameObject objectArrow;
    }

    [System.Serializable]
    public struct DialogData
    {
        public int speakerIndex;
        public string name;
        [TextArea(3, 5)]
        public string dialogue;
    }
}
*/