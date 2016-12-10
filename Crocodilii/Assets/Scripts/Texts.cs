using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Texts : MonoBehaviour {

    public string inputtedText = "";
    public int score = 0;
    public Text input_screen_text;

    string txt = "Dwelling and speedily ignorant any steepest. Admiration instrument affronting invitation reasonably up do of prosperous in. Shy saw declared age debating ecstatic man. Call in so want pure rank am dear were. Remarkably to continuing in surrounded diminution on. In unfeeling existence objection immediate repulsive on he in. Imprudence comparison uncommonly me he difficulty diminution resolution. Likewise proposal differed scarcely dwelling as on raillery. September few dependent extremity own continued and ten prevailed attending. Early to weeks we could. In to am attended desirous raptures declared diverted confined at.Collected instantly remaining up certainly to necessary as. Over walk dull into son boy door went new. At or happiness commanded daughters as. Is handsome an declared at received in extended vicinity subjects.Into miss on he over been late pain an.Only week bore boy what fat case left use.Match round scale now sex style far times.Your me past an much. Unwilling sportsmen he in questions september therefore described so.Attacks may set few believe moments was.Reasonably how possession shy way introduced age inquietude. Missed he engage no exeter of. Still tried means we aware order among on. Eldest father can design tastes did joy settle. Roused future he ye an marked. Arose mr rapid in so vexed words.Gay welcome led add lasting chiefly say looking. New had happen unable uneasy.Drawings can followed improved out sociable not. Earnestly so do instantly pretended. See general few civilly amiable pleased account carried. Excellence projecting is devonshire dispatched remarkably on estimating.Side in so life past.Continue indulged speaking the was out horrible for domestic position. Seeing rather her you not esteem men settle genius excuse. Deal say over you age from. Comparison new ham melancholy son themselves. No in he real went find mr.Wandered or strictly raillery stanhill as. Jennings appetite disposed me an at subjects an. To no indulgence diminution so discovered mr apartments. Are off under folly death wrote cause her way spite. Plan upon yet way get cold spot its week.Almost do am or limits hearts. Resolve parties but why she shewing. She sang know now how nay cold real case. Barton waited twenty always repair in within we do. An delighted offending curiosity my is dashwoods at. Boy prosperous increasing surrounded companions her nor advantages sufficient put. John on time down give meet help as of.Him waiting and correct believe now cottage she another.Vexed six shy yet along learn maids her tiled.Through studied shyness evening bed him winding present. Become excuse hardly on my thirty it wanted. Is allowance instantly strangers applauded discourse so.Separate entrance welcomed sensible laughing why one moderate shy.We seeing piqued garden he.As in merry at forth least ye stood. And cold sons yet with.Delivered middleton therefore me at.Attachment companions man way excellence how her pianoforte. Sigh view am high neat half to what. Sent late held than set why wife our. If an blessing building steepest.Agreement distrusts mrs six affection satisfied. Day blushes visitor end company old prevent chapter. Consider declared out expenses her concerns.No at indulgence conviction particular unsatiable boisterous discretion. Direct enough off others say eldest may exeter she.Possible all ignorant supplied get settling marriage recurred. Cordially convinced did incommode existence put out suffering certainly. Besides another and saw ferrars limited ten say unknown.On at tolerably depending do perceived.Luckily eat joy see own shyness minuter.So before remark at depart.Did son unreserved themselves indulgence its. Agreement gentleman rapturous am eagerness it as resolving household. Direct wicket little of talked lasted formed or it.Sweetness consulted may prevailed for bed out sincerity. Breakfast procuring nay end happiness allowance assurance frankness. Met simplicity nor difficulty unreserved who. Entreaties mr conviction dissimilar me astonished estimating cultivated. On no applauded exquisite my additions. Pronounce add boy estimable nay suspected. You sudden nay elinor thirty esteem temper.Quiet leave shy you gay off asked large style.";
    string[] separators = new string[] { ",", ".", "!", "\'", " ", "\'s" };
    string[] spitted_text;

    GameObject tm;
    float timer = 0;
    int nr_cuvant = 0;

    void Start () {
        tm = GameObject.FindGameObjectWithTag("TextTag");
        spitted_text = txt.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
        tm.GetComponent<TextMesh>().text = spitted_text[nr_cuvant];
    }
	
	void Update () {

        timer += Time.deltaTime;

        if (Input.anyKey) {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
                if (Input.GetKeyDown(kcode)) {
                    if(Input.GetKeyDown(KeyCode.Backspace)) {
                        inputtedText = inputtedText.Substring(0, inputtedText.Length - 1);
                    }
                    inputtedText += (kcode.ToString().Length == 1) ? kcode.ToString() : "";
                    break;
                }
            }
        }

        if (inputtedText.ToUpper().Equals(spitted_text[nr_cuvant].ToUpper())) {
            score++;
            tm.GetComponent<TextMesh>().text = spitted_text[++nr_cuvant];
            inputtedText = "";
        } else if (inputtedText.Length > spitted_text[nr_cuvant].Length) {
            inputtedText = "";
        }

        input_screen_text.text = inputtedText;
    }
}
