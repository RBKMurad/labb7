using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// DecisionNode representerar en nod i beslutsträdet (Uppgift 3)
// Varje nod är antingen en fråga eller ett slutgiltigt råd
public class DecisionNode
{
    // Texten i noden – antingen en fråga eller ett råd
    public string Text { get; set; }

    // True = noden är en fråga, False = noden är ett råd (löv)
    public bool IsQuestion { get; set; }

    // Pekar på nästa nod om användaren svarar "ja"
    public DecisionNode Yes { get; set; }

    // Pekar på nästa nod om användaren svarar "nej"
    public DecisionNode No { get; set; }

    // Konstruktor – skapar en nod med text och typ (fråga eller råd)
    public DecisionNode(string text, bool isQuestion)
    {
        Text = text;
        IsQuestion = isQuestion;
        Yes = null;
        No = null;
    }
}
