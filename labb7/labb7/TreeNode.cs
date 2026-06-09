using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TreeNode representerar en nod i det generella trädet (Uppgift 1)
// Används för att bygga sjukhushierarkin
public class TreeNode
{
    // Namnet på noden, t.ex. "Sjukhuset", "Akuten", "Patient A"
    public string Name { get; set; }

    // Pekar på nodens första barn (nedåt i hierarkin)
    public TreeNode FirstChild { get; set; }

    // Pekar på nästa nod på samma nivå (åt sidan i hierarkin)
    public TreeNode NextSibling { get; set; }

    // Konstruktor – skapar en ny nod med ett namn
    public TreeNode(string name)
    {
        Name = name;
        FirstChild = null;
        NextSibling = null;
    }
}
