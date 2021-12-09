using System;

namespace BinTree
{
	//doma jsem zapomnel pushnout Delete metodu
	class BinTree<T> where T : IComparable<T>
	{
		Node root;
		class Node
		{
			#region operators
			public static bool operator <(Node node, T input)
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
				o = BoringPrintRec(node.L) + " " + o;
			}
			if (node.R != null)
			{
				o = o + " " + BoringPrintRec(node.R);
			}
			return o;
		}
		#endregion



		#region count nodes

		//7) přidejte metodu pro zjištění počtu všech uzlů
		public int CountNodes()
		{
			return CountNodesRec(root);
		}

		private int CountNodesRec(Node n)
		{
			int c = 0;
			if (n == null)
			{
				return c;
			}
			else
			{
				c++;

				c += CountNodesRec(n.L);
				c += CountNodesRec(n.R);

				return c;
			}
		}
		#endregion

		#region frequency
		//8) přidejte metodu pro zjištění počtu výskytů prvku T
		//(ve stromě se prvky se stejnou hodnotou mohou opakovat)
		public int Frequency(T t)
		{
			return FrequencyRec(root, t);
		}
		private int FrequencyRec(Node n, T t)
		{
			int c = 0;
			if (n == null)
			{
				return c;
			}
			else
			{
				if (n == t)
					c++;

				c += FrequencyRec(n.L, t);
				c += FrequencyRec(n.R, t);

				return c;

			}


		}

		#endregion

		#region branch count

		//9) přidejte metodu pro zjištění počtu uzlů s 0, 1 nebo 2 následníky
		//(0, 1, 2 bude vstupní parametr)
		public int BranchCount(int b)
		{
			if (b < 0 || b > 2)
			{
				throw new ArgumentOutOfRangeException("Node can have only 0, 1, or 2 branches");
			}

			if (root == null)
			{
				return 0;
			}

			return BranchCountRec(root, b);
		}
		private int BranchCountRec(Node n, int inputB)
		{
			int c = 0;
			int thisB = 0;

			if (n.L != null)
			{
				thisB++;
				c += BranchCountRec(n.L, inputB);
			}

			if (n.R != null)
			{
				thisB++;
				c += BranchCountRec(n.R, inputB);
			}

			if (thisB == inputB)
			{
				c++;
			}

			return c;
		}

		#endregion

		#region is balanced
		//10) přidejte metodu, která zjistí, zda je strom vyvážený
		//(vzdálenost všech listů od kořene se liší maximálně o 1)
		public bool isBalanced()
		{

			return (Dist(root, true) - Dist(root, false)) <= 1;
		}

		private int Dist(Node n, bool max)
		{
			int dL = (n.L == null) ? 0 : Dist(n.L, max)+1;
			int dR = (n.R == null) ? 0 : Dist(n.R, max)+1;

			if (max)
			{
				//we want the max value
				return (dL > dR) ? dL : dR;
			}
			else
			{
				//we want the min value
				return (dL < dR) ? dL : dR;
			}
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
			tree.Add(1);
			tree.Add(4);
			tree.Add(6);
			tree.Add(8);
			tree.Add(0);
			tree.Add(2);
			tree.Add(9);
			//made it so its fairly balanced
			/*
			                        5
			            3                     7
			    1             4          6           8
			  0   2                                     9
			 
			 */




			Console.WriteLine(tree.BoringPrint());
			Console.WriteLine("Count nodes: " + tree.CountNodes());
			Console.WriteLine("Balanced? " + (tree.isBalanced() ? "true" : "false"));
			Console.WriteLine("frequency(4)" + tree.Frequency(4));
			Console.WriteLine("frequency(2)" + tree.Frequency(2));
			Console.WriteLine("frequency(9)" + tree.Frequency(9));
			Console.WriteLine("-------------------------------");

			tree.Add(4);
			tree.Add(4);
			tree.Add(4);
			tree.Add(2);
			tree.Add(2);
			tree.Add(9);

			/*
									5
						3                     7
				1             4          6           8
			  0   2       4                             9
				 2  	 4                            9
			    2
			 */




			Console.WriteLine(tree.BoringPrint());
			Console.WriteLine("Count nodes: " + tree.CountNodes());
			Console.WriteLine("Balanced? " + (tree.isBalanced() ? "true" : "false"));
			Console.WriteLine("frequency(4)" + tree.Frequency(4));
			Console.WriteLine("frequency(2)" + tree.Frequency(2));
			Console.WriteLine("frequency(9)" + tree.Frequency(9));
			Console.WriteLine("-------------------------------");


		}
	}
}
