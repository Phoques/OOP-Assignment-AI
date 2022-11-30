using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinZone : Zone
{
    [SerializeField] protected Text _winnerText;
    protected static List<GameObject> _winners;

    public HighScoreManager _highscore;

    protected void Start()
    {
        if(_winners == null)
        {
            _winners = new List<GameObject>();
        }
        _winnerText.text = "";

        if(_highscore == null)
            _highscore = FindObjectOfType<HighScoreManager>();
    }

    protected void DisplayWinningText(string marbleName)
    {
        _winnerText.text += marbleName + '\n';
    }

    protected override void ZoneTrigger(GameObject marble)
    {
        if (!_winners.Contains(marble))
        {
            _winners.Add(marble);
            DisplayWinningText(marble.name);
            StartCoroutine(DisableWithDelay(marble, 3f));
            _highscore.GameWon();
        }

    }
}
