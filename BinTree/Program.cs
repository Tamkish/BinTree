using System;
using System.Collections.Generic;

namespace BinTree
{
	class BinTree<T> where T: IComparable<T>
	{
		Node root;
		class Node
		{
			#region operators
			public static bool operator < (Node node, T input)
			{
				return node.data.CompareTo(input) < 0;
			}
			public static bool operator >(Node node, T input)
			{
				return node.data.CompareTo(input) > 0;
			}
			public static bool operator <=(Node node, T input)
			{
				return node.data.CompareTo(input) <= 0;
			}
			public static bool operator >=(Node node, T input)
			{
				return node.data.CompareTo(input) >= 0;
			}
			public static bool operator ==(Node node, T input)
			{
				return node.data.CompareTo(input) == 0;
			}
			public static bool operator !=(Node node, T input)
			{
				return node.data.CompareTo(input) != 0;
			}


			#endregion


			public T data;
			public Node L, R;

			public Node(T input)
			{
				data = input;
			}
		}

		public void Add(T input)
		{
			if (root == null)
			{
				root = new Node(input);
				return;
			}

			AddRecursive(root, input);
		}

		private void AddRecursive(Node root, T input)
		{
			if (root > input)
			{
				if (root.L == null)
				{
					root.L = new Node(input);
				}
				else
				{
					AddRecursive(root.L, input);
				}
			}
			else
			{
				if (root.R == null)
				{
					root.R = new Node(input);
				}
				else
				{
					AddRecursive(root.R, input);
				}
			}
		}

		//todo: recursive print
		#region boring pring
		public string BoringPrint()
		{
			if (root == null)
			{
				return "Empty";
			}

			return BoringPrintRec(root);

		}
		private string BoringPrintRec(Node node)
		{
			string o = node.data.ToString();
			if (node.L != null)
			{
				o = BoringPrintRec(node.L)+" "+o;
			}
			if (node.R != null)
			{
				o = o+" "+BoringPrintRec(node.R);
			}
			return o;
		}
		#endregion

		#region fancy print
		public string FancyPrint()
		{
			
		}

		private string FancyPrintRec()
		{

		}

		private string space(int number)
		{
			string o = "";
			for (int i = 0; i < number; i++)
			{
				o += " ";
			}
			return o;
		}

		#endregion

		//todo: delete
	}


	class Program
	{
		static void Main(string[] args)
		{
			BinTree<int> tree = new BinTree<int>();
			tree.Add(5);
			tree.Add(3);
			tree.Add(7);
			tree.Add(2);
			tree.Add(4);
			tree.Add(6);
			tree.Add(8);
			tree.Add(0);
			tree.Add(1);
			tree.Add(9);

			Console.WriteLine(tree.BoringPrint());
		}
	}
}
