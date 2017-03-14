using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class Voice : MonoBehaviour {

    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;
    public GameObject Burger;
    public GameObject Cake;

	// Use this for initialization
	void Start () {
        m_Keywords = new string[2];
        m_Keywords[0] = "Burger";
        m_Keywords[1] = "Cake";
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
		
	}
	
	// Update is called once per frame
	private void OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        float newX = UnityEngine.Random.Range(-3, 3);
        float newY = UnityEngine.Random.Range(0, 3);
        float newZ = UnityEngine.Random.Range(1, 4);

        if(args.text == m_Keywords[1])
        {
            Instantiate(Cake, new Vector3(newX, newY, newZ), Quaternion.identity);
        }
        if (args.text == m_Keywords[0])
        {
            Instantiate(Burger, new Vector3(newX, newY, newZ), Quaternion.identity);
        }

    }
}
