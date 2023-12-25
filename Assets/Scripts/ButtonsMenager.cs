using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsMenager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;

    [SerializeField] private GameObject _wordTable;
    [SerializeField] private GameObject _addListTable;

    [SerializeField] private TMP_InputField _inputEnglishWord;
    [SerializeField] private TMP_InputField _inputTurkishWord;

    [SerializeField] private TextMeshProUGUI _tableEnglishText;
    [SerializeField] private TextMeshProUGUI _tableTurkishText;

    [SerializeField] private Button _spinTurkish;
    [SerializeField] private Button _spinEnglish;
    [SerializeField] private Button _listTableButton;
    [SerializeField] private Button _getWordbutton;




    public List<string> WordList = new List<string>();
    private int SavedListCount;


    private System.Random random = new System.Random();

    private int previousRandomIndex = -1;


    private void Start()
    {
        LoadList();
    }

    private void Update()
    {
        if (_mainMenu.activeInHierarchy)
        {
            _spinTurkish.gameObject.SetActive(false);
            _spinEnglish.gameObject.SetActive(false);
            _listTableButton.gameObject.SetActive(false);
            _getWordbutton.gameObject.SetActive(false);
            _wordTable.SetActive(false);

        }
        else
        {
            _spinTurkish.gameObject.SetActive(true);
            _listTableButton.gameObject.SetActive(true);
            _getWordbutton.gameObject.SetActive(true);
            _wordTable.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (_addListTable.activeInHierarchy)
            {
                _addListTable.gameObject.SetActive(false);

            }

            else
            {

                _mainMenu.SetActive(true);
            }


        }
    }

    public void Click_Play()
    {

        _mainMenu.SetActive(false);
     
    }

    public void Save_Button()
    {
        string englishWord = _inputEnglishWord.text.Trim();
        string turkishWord = _inputTurkishWord.text.Trim();

        if (!string.IsNullOrEmpty(englishWord) && !string.IsNullOrEmpty(turkishWord))
        {

            WordList.Add(englishWord);
            WordList.Add(turkishWord);



            _inputEnglishWord.text = "";
            _inputTurkishWord.text = "";

            for (int i = 0; i < WordList.Count; i++)
            {
                PlayerPrefs.SetString("words" + i, WordList[i]);
            }

            PlayerPrefs.SetInt("count", WordList.Count);
        }
        else
        {
            Debug.LogError("No Word");
        }

    }
    public void LoadList()
    {
        WordList.Clear();
        SavedListCount = PlayerPrefs.GetInt("count");

        for (int i = 0; i < SavedListCount; i++)
        {
            string kelimeler = PlayerPrefs.GetString("words" + i);
            WordList.Add(kelimeler);
        }

    }
    public void Spin_Turkish()
    {

        if (!_mainMenu.activeInHierarchy)
        {
            _spinEnglish.gameObject.SetActive(true);
        
        }
        _wordTable.transform.DORotate(new Vector3(15, 245, 0), 1.2f);

    }

    public void Spin_English()
    {
        _spinEnglish.gameObject.SetActive(false);
        _wordTable.transform.DORotate(new Vector3(-10, 65, 0), 1.2f);
      
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

            previousRandomIndex = randomIndex;

            
        }
        else
        {
            Debug.LogError("Words listesinde yeterince eleman yok.");
        }
    }

    public void AddListButton()
    {

        _addListTable.SetActive(true);

    }
}






