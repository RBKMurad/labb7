class Program
{
    static void Main(string[] args)
    {
        // Bygg trädet
        TreeNode hospital = new TreeNode("Sjukhuset");

        TreeNode akuten = new TreeNode("Akuten");
        TreeNode kirurgen = new TreeNode("Kirurgen");

        // Sjukhusets barn
        hospital.FirstChild = akuten;
        akuten.NextSibling = kirurgen;

        // Akutens rum
        TreeNode rum1 = new TreeNode("Rum 1");
        TreeNode rum2 = new TreeNode("Rum 2");
        akuten.FirstChild = rum1;
        rum1.NextSibling = rum2;

        // Patienter
        rum1.FirstChild = new TreeNode("Patient A");
        rum2.FirstChild = new TreeNode("Patient B");

        // Kirurgens rum
        TreeNode rum3 = new TreeNode("Rum 3");
        kirurgen.FirstChild = rum3;
        rum3.FirstChild = new TreeNode("Patient C");

        // Kör traverseringen
        Console.WriteLine(" Sjukhushierarki ");
        TraversePreOrder(hospital, 0);

        // UPPGIFT 2  Binärt sökträd (Tidbokning)
        Console.WriteLine("\n Tidbokningar (osorterad inmatning) ");

        BookingNode root = null;
        root = Insert(root, "10:30", "Anna Svensson");
        root = Insert(root, "08:00", "Erik Johansson");
        root = Insert(root, "14:00", "Maria Lindgren");
        root = Insert(root, "09:15", "Karl Bergström");
        root = Insert(root, "11:45", "Sara Nilsson");

        TraverseInOrder(root);

        // Mer balanserad inmatning
        Console.WriteLine("\n Tidbokningar (balanserad inmatning) ");

        BookingNode root2 = null;
        root2 = Insert(root2, "10:00", "Mitten Patient");
        root2 = Insert(root2, "08:00", "Tidig Patient");
        root2 = Insert(root2, "12:00", "Sen Patient");
        root2 = Insert(root2, "07:00", "Mycket Tidig");
        root2 = Insert(root2, "09:00", "Lite Tidig");

        TraverseInOrder(root2);

        //  UPPGIFT 3 – Beslutsträd (Diagnosexpert) 
        Console.WriteLine("\n Digital Diagnosexpert ");

        // Bygg beslutsträdet
        DecisionNode root3 = new DecisionNode("Har du feber?", true);

        root3.Yes = new DecisionNode("Har du svårt att andas?", true);
        root3.No = new DecisionNode("Har du ont i halsen?", true);

        root3.Yes.Yes = new DecisionNode("Ring 112 omedelbart!", false);
        root3.Yes.No = new DecisionNode("Stanna hemma och vila, drick mycket vatten.", false);

        root3.No.Yes = new DecisionNode("Du kan ha halsfluss, kontakta vårdcentral.", false);
        root3.No.No = new DecisionNode("Du verkar frisk, vila och observera symptomen.", false);

        // Kör diagnosen
        RunDiagnosis(root3);
    }


    // Statisk pre-order traversal
    static void TraversePreOrder(TreeNode node, int level)
    {
        if (node == null) return;

        string indent = new string(' ', level * 4);
        Console.WriteLine(indent + node.Name);

        TraversePreOrder(node.FirstChild, level + 1);
        TraversePreOrder(node.NextSibling, level);
    }
    static BookingNode Insert(BookingNode node, string time, string patientName)
    {
        if (node == null)
            return new BookingNode(time, patientName);

        if (string.Compare(time, node.Time) < 0)
            node.Left = Insert(node.Left, time, patientName);
        else if (string.Compare(time, node.Time) > 0)
            node.Right = Insert(node.Right, time, patientName);

        return node;
    }

    static void TraverseInOrder(BookingNode node)
    {
        if (node == null) return;

        TraverseInOrder(node.Left);
        Console.WriteLine($"  {node.Time} – {node.PatientName}");
        TraverseInOrder(node.Right);
    }
    //  UPPGIFT 3 – Iterativ traversal 
    static void RunDiagnosis(DecisionNode root)
    {
        DecisionNode current = root;

        while (current.IsQuestion)
        {
            Console.WriteLine("\n" + current.Text);
            Console.Write("Svar (ja eller nej): ");
            string answer = Console.ReadLine().ToLower().Trim();

            if (answer == "ja")
                current = current.Yes;
            else
                current = current.No;
        }

        Console.WriteLine("\n>>> Råd för dig: " + current.Text);
    }


}
