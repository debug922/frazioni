using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frazioni {
	class Program {
		static void Main(string[] args) {
			
			Console.WriteLine(Mcd(12,9));
			Console.WriteLine(Mcd(90,525));
			Console.ReadLine();

		}

		private static int Mcd(int a, int b) {
			int r;
			while (b > 0) {
				r = a % b;
				a = b;
				b = r;
			}
			return a;
		}
	}


}
