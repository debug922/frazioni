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
				_numeratore = -1 * _numeratore;
				_denominatore = -1 * _denominatore;
				
			}
		}

		private void CheckFrazione()
		{
			
			int mcd = _numeratore<0 ? Mcd(-1*_numeratore, _denominatore) : Mcd(_numeratore, _denominatore);
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
	}
}
