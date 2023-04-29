using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using UnityEngine.UI;
using System.Linq;

public class GameEndScreen : AnimatedWindowBase
{
    [SerializeField] private PlayersTopView top;
    [SerializeField] private TopItem prefabItem;
    [SerializeField] private Button homeBtn;
    [SerializeField] private RectTransform itemsContainer;

    Connections connections = new Connections();
    public void Show(GameModel model,List<PlayerModel> all, PlayerModel player)
    {
        connections.DisconnectAll();
        all.OrderByDescending(p => p.Scores.value).ToList();
        // top.Present(all, player);
        homeBtn.OnClick(() => GameSession.Instance.EndGame(model));
        
        connections += all.Present(prefabItem, itemsContainer, (view, model) =>
        {
            view.Show(model);
            if (model == player)
            {
                view.transform.localScale *= 1.1f;
                view.SetColors(Color.white, Color.blue);
            }
        });
    }
}
