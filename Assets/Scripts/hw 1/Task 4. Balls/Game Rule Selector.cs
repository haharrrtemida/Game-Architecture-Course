using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRuleSelector : MonoBehaviour
{
    [SerializeField] private Button _burstAllBallsButton;
    [SerializeField] private Button _burstOneColoredBallsButton;
    [SerializeField] private TMPro.TMP_Dropdown _selectedColorDropdown;
    [SerializeField] private GameManager _game;
    
    // Всё это решение со словарём мне кажется очень громоздким
    // но хотел, чтобы в UI было по-русски, сделал такой костыль, не бей 🙏
    // Вроде это нужно делать через отдельную таблицу, где и делается вся локализация
    // но хотел бы послушать твоё мнение о том, как можно было это решить
    private Dictionary<string, string> _localization = new Dictionary<string, string>()
    {
        { "Красный", "Red" },
        { "Белый", "White" },
        { "Зелёный", "Green" }
    };

    private void Awake()
    {
        _burstAllBallsButton.onClick.AddListener(() => {
            _game.SetGameRule(new BurstAllBallsRule(_game));
            Destroy(gameObject);
        });
        _burstOneColoredBallsButton.onClick.AddListener(() => {
            int selectedItemIndex = _selectedColorDropdown.value;
            string selectedColorName = _selectedColorDropdown.options[selectedItemIndex].text;
            var selectedBallColor = (BallColor)Enum.Parse(typeof(BallColor), _localization[selectedColorName]);
            _game.SetGameRule(new BurstOneColoredBallsRule(_game, selectedBallColor));
            Destroy(gameObject);
        });
    }
}