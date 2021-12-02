using System;
using System.Collections.Generic;

namespace BinTree
{
	class BinTree<T> where T: IComparable<T>
	{
		Node root;



		class Node
		{
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

		public void AddRecursive(Node root, T input)
		{
			if (input < root.data)
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
	}


	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
}
