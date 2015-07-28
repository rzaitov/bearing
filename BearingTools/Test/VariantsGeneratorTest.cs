using NUnit.Framework;

using Core;

namespace Test
{
	[TestFixture]
	public class VariantsGeneratorTest
	{
		[Test]
		public void SkfVariants ()
		{
			var builder = new GeneratorBuilder ("skf");
			var generator = builder.Build ();

			var expected = new string[] {
				"SKF",
				"СКФ"
			};
			CollectionAssert.AreEqual (expected, generator.GetVariants ());
		}

		[Test]
		public void UniqVariant ()
		{
			var builder = new GeneratorBuilder ("xyz");
			var generator = builder.Build ();

			var expected = new string[] {
				"xyz"
			};
			CollectionAssert.AreEqual (expected, generator.GetVariants ());
		}

		[Test]
		public void VariantWitSingleSeparator ()
		{
			var builder = new GeneratorBuilder ("abc-xyz");
			var generator = builder.Build ();

			var expected = new string[] {
				"abc-xyz",
				"abc xyz",
				"abcxyz"
			};
			CollectionAssert.AreEquivalent (expected, generator.GetVariants ());
		}

		[Test]
		public void VariantWitMultiSeparator ()
		{
			var builder = new GeneratorBuilder ("a + b");
			var generator = builder.Build ();

			var variants = generator.GetVariants ();
			var expected = new string[] {
				"a + b",
				"a+ b",
				"a +b",
				"a+b",
				"a b",
				"ab"
			};
			CollectionAssert.AreEquivalent (expected, variants);
		}
	}
}