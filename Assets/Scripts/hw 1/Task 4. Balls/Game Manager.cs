using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallsSpawner _spawner;
    [SerializeField] private TextMeshProUGUI _resultText;
    private IGameRule _gameRule;

    public BallsSpawner Spawner => _spawner;

    public void SetGameRule(GameRule rule)
    {
        _gameRule = rule;
        _spawner.Initialize();
        foreach (Ball ball in _spawner.BallsCollection)
        {
            ball.OnBallClicked += _spawner.RemoveBallFromCollection;
            ball.OnBallClicked += _gameRule.CheckBurstBall;
            _gameRule.OnWinGame += SetwResultWinText;
            _gameRule.OnLoseGame += SetwResultLoseText;
        }
    }

    private void SetwResultWinText()
    {
        _resultText.text = "Вы победили!";
        DeactivateAllBalls();
    }

    private void SetwResultLoseText()
    {
        _resultText.text = "Вы проиграли!";
        DeactivateAllBalls();
    }

    private void DeactivateAllBalls()
    {
        foreach (Ball ball in Spawner.BallsCollection)
        {
            Destroy(ball.GetComponent<Ball>());
        }
    }
}