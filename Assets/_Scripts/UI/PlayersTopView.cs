using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;

public class PlayersTopView : MonoBehaviour
{
    [SerializeField] private TopItem prefab;
    [SerializeField] private RectTransform itemsContainer;
    private List<TopItem> views = new();
    Connections connections = new Connections();
    public void Present(List<PlayerModel> oponents, PlayerModel player)
    {
        connections.DisconnectAll();
        oponents.Add(player);// TODO BAD CODE
        var presenter = oponents.Present(prefab, itemsContainer, (view, model) =>
        {
            view.Show(model);
            if (model == player)
            {
                view.transform.localScale *= 1.1f;
                view.SetColors(Color.white, Color.blue);
            }
        });
        connections += presenter;
        views = presenter.views;

    }
    private void SortViews()
    {
        if (views.Count == 0) return;
        views = views.OrderByDescending(v => v.currentModel.Scores.value).ToList();
        for (int i = 0; i < views.Count; i++)
        {
            views[i].transform.SetSiblingIndex(i);
        }
    }
    private void Update()
    {
        SortViews();
    }
}
