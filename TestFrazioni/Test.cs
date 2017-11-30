using System;
using frazioni;
using NUnit.Framework;

namespace TestFrazioni
{
	[TestFixture]
	public class Test
    {
		[Test]
	    public void Frazioni_Frazioni_ok()
	    {
		    var f= new Frazioni(1,2);
			Assert.That(f,!Is.Null);
	    }
	    public void Frazioni_Frazioni_Zero() {
		    Assert.That(()=>new Frazioni(1,0),Throws.TypeOf<ArgumentException>());
	    }
	    [Test]
	    public void Frazioni_Frazioni_Negative() {
		    var f = new Frazioni(11, -12);
		    Assert.That(f.Numeratore, Is.EqualTo(-11));
		    Assert.That(f.Denominatore, Is.EqualTo(12));

	    }
		[Test]
	    public void Frazioni_Frazioni_Normal1() {
		    var f = new Frazioni(90,-525);
		    Assert.That(f.Numeratore, Is.EqualTo(-6));
			Assert.That(f.Denominatore, Is.EqualTo(35));


		}
		[Test]
	    public void Frazioni_Frazioni_Normal2() {
		    var f = new Frazioni(22, 11);
		    Assert.That(f.Numeratore, Is.EqualTo(2));
		    Assert.That(f.Denominatore, Is.EqualTo(1));
	    }
		[Test]
	    public void Frazioni_ToString_SoloNumeratore() {
		    var f = new Frazioni(22, -11);
		    Assert.That(f.ToString(), Is.EqualTo("-2"));
		 
	    }
		[Test]
	    public void Frazioni_ToString_NumEdDen() {
		    var f = new Frazioni(23, -11);
		    Assert.That(f.ToString(), Is.EqualTo("-23/11"));

	    }
		[Test]
		public void Frazioni_Equals_NumEdDen() {
		    var f = new Frazioni(23, -11);
		    Assert.That(f.Equals(new Frazioni(-23,11)), Is.True);

	    }
		[Test]
		public void Frazioni_Equals_Num() {
			var f = new Frazioni(1,2);
			Assert.That(f.Equals(new Frazioni(2,4)), Is.True);

		}
	    [Test]
	    public void Frazioni_Equals_Zero() {
		    var f = new Frazioni(0, 2);
		    Assert.That(f.Equals(new Frazioni(0, 4)), Is.True);

	    }
	    [Test]
	    public void Frazioni_Equals_false() {
		    Assert.That(()=>new Frazioni(1,2).Equals(new Object()),Is.False);
	    }
		[Test]
		public void Frazioni_Conversion_ok() {
			var f = new Frazioni(4, 2);
			Assert.That(f.Conversion(),Is.EqualTo(2));

		}
		[Test]
	    public void Frazioni_Conversion_Exception() {
		    Assert.That(() => new Frazioni(1, 2).Conversion(), Throws.TypeOf<ArgumentException>());
	    }
		[Test]
		public void Frazioni_Plus_OK() {
			Assert.That(new Frazioni(1,2)+new Frazioni(2,5),Is.EqualTo(new Frazioni(9,10)));
		}
	    public void Frazioni_Plus_OK1() {
		    Assert.That(new Frazioni(1, 2) + new Frazioni(1, 2), Is.EqualTo(new Frazioni(1, 1)));
	    }
	}
}
