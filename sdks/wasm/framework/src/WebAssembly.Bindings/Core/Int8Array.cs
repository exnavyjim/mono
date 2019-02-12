﻿using System;
namespace WebAssembly.Core {
	public sealed class Int8Array : TypedArray<Int8Array, sbyte> {
		public Int8Array ()
		{ }

		public Int8Array (int length) : base (length)
		{ }


		public Int8Array (ArrayBuffer buffer) : base (buffer)
		{ }

		public Int8Array (ArrayBuffer buffer, int byteOffset) : base (buffer, byteOffset)
		{ }

		public Int8Array (ArrayBuffer buffer, int byteOffset, int length) : base (buffer, byteOffset, length)
		{ }

		internal Int8Array (IntPtr js_handle) : base (js_handle)
		{ }


		// Define the indexer to allow client code to use [] notation.
		public sbyte? this [int i] {
			get {
				var indexValue = Runtime.GetByIndex (JSHandle, i, out int exception);

				if (exception != 0)
					throw new JSException ((string)indexValue);

				if (indexValue != null)
					// The value returned from the index will be an int32 so use Convert to
					// return a byte value.  
					return Convert.ToSByte (indexValue);
				else
					return null;
			}
			set {
				var res = Runtime.SetByIndex (JSHandle, i, value, out int exception);

				if (exception != 0)
					throw new JSException ((string)res);

			}
		}

		/// <summary>
		/// From the specified segment.
		/// </summary>
		/// <returns>The from.</returns>
		/// <param name="segment">Segment.</param>
		public static Int8Array From (ArraySegment<sbyte> segment)
		{
			var ta = new Int8Array (segment.Count);
			ta.CopyFrom (segment);
			return ta;
		}

		/// <summary>
		/// Defines an implicit conversion of a <see cref="ArraySegment{T}"/> to a <see cref="T:WebAssembly.Core.Int8Array"/>/>
		/// </summary>
		/// <returns>The implicit.</returns>
		/// <param name="segment">ArraySegment</param>
		public static implicit operator Int8Array (ArraySegment<sbyte> segment) => From (segment);


		/// <summary>
		/// Defines an implicit conversion of an array to a <see cref="T:WebAssembly.Core.Int8Array"/>./>
		/// </summary>
		/// <returns>The implicit.</returns>
		/// <param name="typedarray">Typedarray.</param>
		public static implicit operator sbyte [] (Int8Array typedarray)
		{
			return typedarray.ToArray ();
		}

		/// <summary>
		/// Defines an implicit conversion of <see cref="T:WebAssembly.Core.Int8Array"/> to an array./>
		/// </summary>
		/// <returns>The implicit.</returns>
		/// <param name="managedArray">Managed array.</param>
		public static implicit operator Int8Array (sbyte [] managedArray)
		{
			return From (managedArray);
		}


	}
}
