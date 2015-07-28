using System;
using NUnit.Framework;

using Core;

namespace Tests
{
	[TestFixture ()]
	public class GeneratorBuilderTest
	{
		[Test()]
		public void FindSeparators()
		{
			var builder = new GeneratorBuilder ("abc xyz/123-456*789");
			CollectionAssert.AreEqual (new int[]{ 3, 7, 11, 15 }, builder.FindSeparators ());
		}

		[Test ()]
		public void GetNextChunk ()
		{
			var builder = new GeneratorBuilder ("abc xyz/123-456*789");
			Assert.AreEqual ("abc", builder.GetNextChunk ());
			Assert.AreEqual (" ", builder.GetNextChunk ());
			Assert.AreEqual ("xyz", builder.GetNextChunk ());
			Assert.AreEqual ("/", builder.GetNextChunk ());
			Assert.AreEqual ("123", builder.GetNextChunk ());
			Assert.AreEqual ("-", builder.GetNextChunk ());
			Assert.AreEqual ("456", builder.GetNextChunk ());
			Assert.AreEqual ("*", builder.GetNextChunk ());
			Assert.AreEqual ("789", builder.GetNextChunk ());
			Assert.AreEqual (null, builder.GetNextChunk ());
		}

		[Test()]
		public void MultipleSeparators ()
		{
			var builder = new GeneratorBuilder ("abc /*-xyz");
			Assert.AreEqual ("abc", builder.GetNextChunk ());
			Assert.AreEqual (" ", builder.GetNextChunk ());
			Assert.AreEqual ("/", builder.GetNextChunk ());
			Assert.AreEqual ("*", builder.GetNextChunk ());
			Assert.AreEqual ("-", builder.GetNextChunk ());
			Assert.AreEqual ("xyz", builder.GetNextChunk ());
		}
	}
}