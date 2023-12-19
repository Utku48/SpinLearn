using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsMenager : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Animator _kyleAnimator;
    [SerializeField] private GameObject _wordTable;

    [SerializeField] private TMP_InputField _inputEnglishWord;
    [SerializeField] private TMP_InputField _inputTurkishWord;

    [SerializeField] private TextMeshProUGUI _tableEnglishText;
    [SerializeField] private TextMeshProUGUI _tableTurkishText;

    [SerializeField] private Button _spinTurkish;
    [SerializeField] private Button _spinEnglish;




    public List<string> WordList = new List<string>();


    private System.Random random = new System.Random();

    private int previousRandomIndex = -1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _panel.SetActive(true);
        }
    }

    public void Click_Play()
    {
        _panel.SetActive(false);
        _kyleAnimator.SetBool("idle", true);
    }

    public void Save_Button()
    {
        string englishWord = _inputEnglishWord.text.Trim();
        string turkishWord = _inputTurkishWord.text.Trim();

        if (!string.IsNullOrEmpty(englishWord) && !string.IsNullOrEmpty(turkishWord))
        {

            WordList.Add(englishWord);
            WordList.Add(turkishWord);

            _kyleAnimator.SetBool("turn", true);

            _inputEnglishWord.text = "";
            _inputTurkishWord.text = "";
        }
        else
        {
            Debug.LogError("No Word");
        }

    }

    public void Spin_Turkish()
    {
        _spinEnglish.gameObject.SetActive(true);
        _wordTable.transform.DORotate(new Vector3(0, 245, 0), 3f);
        _spinTurkish.gameObject.SetActive(false);
    }

    public void Spin_English()
    {
        _spinTurkish.gameObject.SetActive(true);
        _wordTable.transform.DORotate(new Vector3(0, 65, 0), 1.2f);
        _spinEnglish.gameObject.SetActive(false);
    }

    public void Get_Word_Button()
    {

        if (WordList.Count >= 2)
        {
            int randomIndex;

            do
            {
                // Rastgele bir çift sayı seç
                randomIndex = random.Next(0, WordList.Count / 2) * 2;
            }
            while (randomIndex == previousRandomIndex);

            _tableEnglishText.text = WordList[randomIndex];
            _tableTurkishText.text = WordList[randomIndex + 1];

            // Şu anki rastgele sayıyı sakla
            previousRandomIndex = randomIndex;
        }
        else
        {
            Debug.LogError("Words listesinde yeterince eleman yok.");
        }
    }
}






