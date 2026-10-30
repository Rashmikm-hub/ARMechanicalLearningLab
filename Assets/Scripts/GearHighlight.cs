using UnityEngine;

public class GearHighlight : MonoBehaviour
{
    private Renderer[] gearRenderers;
    private Color[] originalColors;

    public Color highlightColor = Color.yellow;

    void Awake()
    {
        gearRenderers = GetComponentsInChildren<Renderer>();

        originalColors = new Color[gearRenderers.Length];

        for (int i = 0; i < gearRenderers.Length; i++)
        {
            originalColors[i] = gearRenderers[i].material.color;
        }
    }

    public void HighlightGear(bool highlight)
    {
        for (int i = 0; i < gearRenderers.Length; i++)
        {
            if (highlight)
            {
                gearRenderers[i].material.color = highlightColor;
            }
            else
            {
                gearRenderers[i].material.color = originalColors[i];
            }
        }
    }
}