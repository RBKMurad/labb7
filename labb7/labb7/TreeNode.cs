using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TreeNode
{
    public string Name { get; set; }
    public TreeNode FirstChild { get; set; }
    public TreeNode NextSibling { get; set; }

    public TreeNode(string name)
    {
        Name = name;
        FirstChild = null;
        NextSibling = null;
    }
}
