class Program
{
    static void Main(string[] args)
    {
        
        // UPPGIFT 1 – Generellt träd (Sjukhushierarki)
       

        // Skapar rotnoden – hela sjukhuset
        TreeNode hospital = new TreeNode("Sjukhuset");

        // Skapar avdelningar
        TreeNode akuten = new TreeNode("Akuten");
        TreeNode kirurgen = new TreeNode("Kirurgen");

        // Kopplar avdelningarna till sjukhuset
        // Akuten är FirstChild, Kirurgen är NextSibling till Akuten
        hospital.FirstChild = akuten;
        akuten.NextSibling = kirurgen;

        // Skapar rum och kopplar till Akuten
        TreeNode rum1 = new TreeNode("Rum 1");
        TreeNode rum2 = new TreeNode("Rum 2");
        akuten.FirstChild = rum1;
        rum1.NextSibling = rum2; // Rum 2 är syskon till Rum 1

        // Kopplar patienter till respektive rum
        rum1.FirstChild = new TreeNode("Patient A");
        rum2.FirstChild = new TreeNode("Patient B");

        // Skapar rum och patient för Kirurgen
        TreeNode rum3 = new TreeNode("Rum 3");
        kirurgen.FirstChild = rum3;
        rum3.FirstChild = new TreeNode("Patient C");

        // Startar pre-order traversal från roten på nivå 0
        Console.WriteLine("=== Sjukhushierarki ===");
        TraversePreOrder(hospital, 0);

        // UPPGIFT 2 – Binärt sökträd (Tidbokning)
        

        Console.WriteLine("\n=== Tidbokningar (osorterad inmatning) ===");

        // Skapar ett tomt BST och lägger in bokningar i osorterad ordning
        // Trädet sorterar automatiskt baserat på tid
        BookingNode root = null;
        root = Insert(root, "10:30", "Anna Svensson");
        root = Insert(root, "08:00", "Erik Johansson");
        root = Insert(root, "14:00", "Maria Lindgren");
        root = Insert(root, "09:15", "Karl Bergström");
        root = Insert(root, "11:45", "Sara Nilsson");

        // In-order traversal ger sorterad utskrift (kronologisk ordning)
        TraverseInOrder(root);

        Console.WriteLine("\n=== Tidbokningar (balanserad inmatning) ===");

        // Lägger in bokningar i mer balanserad ordning (mitten först)
        BookingNode root2 = null;
        root2 = Insert(root2, "10:00", "Mitten Patient");
        root2 = Insert(root2, "08:00", "Tidig Patient");
        root2 = Insert(root2, "12:00", "Sen Patient");
        root2 = Insert(root2, "07:00", "Mycket Tidig");
        root2 = Insert(root2, "09:00", "Lite Tidig");

        TraverseInOrder(root2);

        
        // UPPGIFT 3 – Beslutsträd ´ (Digital Diagnosexpert)
        

        Console.WriteLine("\n=== Digital Diagnosexpert ===");

        // Bygger beslutsträdet – varje nod är en fråga eller ett råd
        DecisionNode root3 = new DecisionNode("Har du feber?", true);

        // Kopplar grenar baserat på ja/nej-svar
        root3.Yes = new DecisionNode("Har du svårt att andas?", true);
        root3.No = new DecisionNode("Har du ont i halsen?", true);

        // Löv – slutgiltiga råd (IsQuestion = false)
        root3.Yes.Yes = new DecisionNode("Ring 112 omedelbart!", false);
        root3.Yes.No = new DecisionNode("Stanna hemma och vila, drick mycket vatten.", false);
        root3.No.Yes = new DecisionNode("Du kan ha halsfluss, kontakta vårdcentral.", false);
        root3.No.No = new DecisionNode("Du verkar frisk, vila och observera symptomen.", false);

        // Startar diagnosen – navigerar iterativt genom trädet
        RunDiagnosis(root3);
    }

    
    // METOD: TraversePreOrder (Uppgift 1)
    // Pre-order traversal: Besök nod → FirstChild → NextSibling
    // Rekursiv metod som skriver ut trädet med indrag per nivå
    
    static void TraversePreOrder(TreeNode node, int level)
    {
        // Basfall – om noden är null, stoppa rekursionen
        if (node == null) return;

        // Skapar indrag baserat på nivå (4 mellanslag per nivå)
        string indent = new string(' ', level * 4);
        Console.WriteLine(indent + node.Name);

        // Går ner till första barnet (ökar nivån med 1)
        TraversePreOrder(node.FirstChild, level + 1);

        // Går till nästa syskon (samma nivå)
        TraversePreOrder(node.NextSibling, level);
    }

    
    // METOD: Insert (Uppgift 2)
    // Lägger in en ny bokning på rätt plats i BST
    // Tidigare tider går till vänster, senare till höger
    
    static BookingNode Insert(BookingNode node, string time, string patientName)
    {
        // Basfall – platsen är ledig, skapa ny nod här
        if (node == null)
            return new BookingNode(time, patientName);

        // Jämför den nya tiden med nuvarande nod
        if (string.Compare(time, node.Time) < 0)
            node.Left = Insert(node.Left, time, patientName);   // Tidigare → vänster
        else if (string.Compare(time, node.Time) > 0)
            node.Right = Insert(node.Right, time, patientName); // Senare → höger
        // Om lika tid ignoreras den (dubbletter hanteras ej)

        return node;
    }

    
    // METOD: TraverseInOrder (Uppgift 2)
    // In-order traversal: Vänster → Nod → Höger
    // Ger automatiskt sorterad (kronologisk) utskrift i BST
    
    static void TraverseInOrder(BookingNode node)
    {
        // Basfall – om noden är null, stoppa rekursionen
        if (node == null) return;

        // Gå vänster först (tidigare tider)
        TraverseInOrder(node.Left);

        // Skriv ut nuvarande nod
        Console.WriteLine($"  {node.Time} – {node.PatientName}");

        // Gå höger sist (senare tider)
        TraverseInOrder(node.Right);
    }

   
    // METOD: RunDiagnosis (Uppgift 3)
    // Iterativ traversal med while-loop (ingen rekursion)
    // Navigerar i beslutsträdet baserat på användarens svar
    
    static void RunDiagnosis(DecisionNode root)
    {
        // Startar vid roten av beslutsträdet
        DecisionNode current = root;

        // Fortsätter så länge noden är en fråga (IsQuestion = true)
        // Loopen är generisk – all logik finns i noderna, inte här
        while (current.IsQuestion)
        {
            Console.WriteLine("\n" + current.Text);
            Console.Write("Svar (ja/nej): ");
            string answer = Console.ReadLine().ToLower().Trim();

            // Navigera till Yes eller No beroende på svar
            if (answer == "ja")
                current = current.Yes;
            else
                current = current.No;
        }

        // Vi har nått ett löv (IsQuestion = false) – skriv ut rådet
        Console.WriteLine("\n>>> Råd: " + current.Text);
    }
}
