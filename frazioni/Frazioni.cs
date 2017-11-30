using System;


namespace frazioni {
	public class Frazioni
	{
		private int _numeratore, _denominatore;
		public Frazioni(int n, int d)
		{
			_numeratore = n;
			_denominatore = d;
			CheckDenominatore();
			CheckFrazione();
			
		}

		public Frazioni(int n)
		{
			_denominatore = 1;
			_numeratore = n;
		}


		public int Numeratore
		{
			get => _numeratore;
			set
			{
				_numeratore = value;
				CheckFrazione();
			}
		}

		public int Denominatore
		{
			set
			{
				_denominatore = value;
				CheckDenominatore();
				CheckFrazione();
			}

			get => _denominatore;
		}

		private void CheckDenominatore()
		{
			if(_denominatore==0)
				throw new ArgumentException("zero");
			if (_denominatore < 0)
			{
				_numeratore = Abs(_numeratore);
				_denominatore = Abs(_denominatore);
				
			}
		}

		private int Abs(int n )
		{
			return -1 *n;
		}

		private void CheckFrazione()
		{
			
			int mcd = _numeratore<0 ? Mcd(Abs(_numeratore), _denominatore) : Mcd(_numeratore, _denominatore);
			if (mcd > 1)
			{
				_numeratore/=mcd;
				_denominatore /= mcd;
			}
		}

		private int Mcd(int a, int b) {
			int r;
			while (b > 0) {
				r = a % b;
				a = b;
				b = r;
			}
			return a;
		}

		public override string ToString()
		{
			if (_denominatore == 1)
				return _numeratore.ToString();
			return _numeratore + "/" + _denominatore;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Frazioni))
				return  false;
			Frazioni fr = (Frazioni) obj;
			if (fr.Numeratore == 0 && Numeratore == 0)
				return true;
			return Numeratore==fr.Numeratore && Denominatore==fr.Denominatore;
		}

		protected bool Equals(Frazioni other)
		{
			return Equals((object)other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (_numeratore * 397) ^ _denominatore;
			}
		}

		public int Conversion()
		{
			if(Denominatore>1)
				throw  new ArgumentException("Conversione");
			return Numeratore;
		}

		public static Frazioni operator +(Frazioni f1, Frazioni f2)
		{
			//x1/y1+x2/y2=((x1*y2)+(x2*y1))/(y1*y2)
			int n = f1.Numeratore * f2.Denominatore + f2.Numeratore * f1.Denominatore;
			if (n == 0)
				return new Frazioni(n, 1);

			return new Frazioni(n, f1.Denominatore * f2.Denominatore);

		}
		public static Frazioni operator -(Frazioni f1, Frazioni f2) {
			//x1/y1-x2/y2=((x1*y2)-(x2*y1))/(y1*y2)
			int n = f1.Numeratore * f2.Denominatore - f2.Numeratore * f1.Denominatore;
			if(n==0)
				return new Frazioni(n,1);

			return new Frazioni(n, f1.Denominatore * f2.Denominatore);


		}
		public static Frazioni operator *(Frazioni f1, Frazioni f2) {
			//(x1 / y1) * (x2 / y2) = (x1 * x2) / (y1 * y2)
			if(f1.Numeratore==0 || f2.Numeratore==0)
				return  new Frazioni(0,1);

			return new Frazioni(f1.Numeratore * f2.Numeratore ,f1.Denominatore * f2.Denominatore);

		}
		public static Frazioni operator /(Frazioni f1, Frazioni f2) {
			//se x2<>0, (x1/y1)/(x2/y2)=(x1*y2)/(y1*x2)
			if(f2.Numeratore==0)
				throw new ArgumentException("diviso 0");

			return new Frazioni(f1.Numeratore * f2.Denominatore, f1.Denominatore * f2.Numeratore);

		}

	}
}
