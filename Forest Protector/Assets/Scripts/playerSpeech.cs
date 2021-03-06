using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerSpeech : MonoBehaviour
{

    [SerializeField] private int maxLength = 100;
    
    [SerializeField]
    private GameObject panelImg;

    List<List<string>> conversation = new List<List<string>>();
    
    [SerializeField]
    private TextMeshProUGUI textBox;
    // Start is called before the first frame update

    private bool active;
    void Start()
    {
        active = false;
        // Add all the Conversation u want and iterate through them through them...>!
        conversation.Add(new List<string>(){"Hi I am the forest protector","Help me in protecting this forest","There are traps and hunters all along the forest... so be careful."});
        conversation.Add(new List<string>(){"Hey who are you","Why are you trapping these innocent animals","I'll not let you do this"});
        conversation.Add(new List<string>(){"I Should knock out all enemies in the area first"});
        conversation.Add(new List<string>(){"I should ensure these campers are paying heed to cleanliness"});
        // conversation.Add(new List<string>(){"Why are you campers throwing garbage in public places","If we protect the nature, the nature will protect us","Keeping this environment clean is our responsibility"});
        // conversation.Add(new List<string>(){"Oh sorry we will not repeat this again","Good. Tell your friends as well","Protect nature and the LIFE ON EARTH"});
        Debug.Log(conversation[0][0]);
        StartCoroutine(Speech(conversation[0]));
    }


    public void startConversation(int Number){
        if(active==false){
            StartCoroutine(Speech(conversation[Number]));
        }
    }
    IEnumerator Speech(List<string> conversation){

        if(active == false){
            active = true;
            yield return new WaitForSeconds(1f);
            panelImg.SetActive(true);

            foreach(string s in conversation){
                textBox.text = "";
                for(int i=0;i<s.Length;i++){
                    yield return new WaitForSeconds(0.1f);
                    textBox.text = textBox.text + s[i];
                }
                yield return new WaitForSeconds(2f);
            }
            StopCoroutine("Speech");
            panelImg.SetActive(false);
            active = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
