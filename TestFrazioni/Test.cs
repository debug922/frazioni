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
	    public void Frazioni_Frazioni_Normal2() {
		    var f = new Frazioni(22, 11);
		    Assert.That(f.Numeratore, Is.EqualTo(2));
		    Assert.That(f.Denominatore, Is.EqualTo(1));
	    }
	    public void Frazioni_ToString_SoloNumeratore() {
		    var f = new Frazioni(22, -11);
		    Assert.That(f.ToString(), Is.EqualTo("-2"));
		 
	    }


	}
}
