using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ImGuiNET;

public static unsafe class Util {
	public const int StackAllocationSizeLimit = 2048;

	public static string StringFromPtr(byte* ptr) {
		var characters = 0;
		while(ptr[characters] != 0) {
			characters++;
		}

		return Encoding.UTF8.GetString(ptr, characters);
	}

	public static bool AreStringsEqual(byte* a, int aLength, byte* b) {
		for(var i = 0; i < aLength; i++) {
			if(a[i] != b[i]) { return false; }
		}

		return b[aLength] == 0;
	}

	public static byte* Allocate(int byte_count) => (byte*)Marshal.AllocHGlobal(byte_count);

	public static void Free(byte* ptr) => Marshal.FreeHGlobal((IntPtr)ptr);

	public static int CalcSizeInUtf8(string s, int start, int length) {
		if(start < 0 || length < 0 || start + length > s.Length) {
			throw new ArgumentOutOfRangeException();
		}

		fixed(char* utf_16_ptr = s) {
			return Encoding.UTF8.GetByteCount(utf_16_ptr + start, length);
		}
	}

	public static int GetUtf8(string s, byte* utf_8_bytes, int utf_8_byte_count) {
		fixed(char* utf_16_ptr = s) {
			return Encoding.UTF8.GetBytes(utf_16_ptr, s.Length, utf_8_bytes, utf_8_byte_count);
		}
	}

	public static int GetUtf8(string s, int start, int length, byte* utf_8_bytes, int utf_8_byte_count) {
		if(start < 0 || length < 0 || start + length > s.Length) {
			throw new ArgumentOutOfRangeException();
		}

		fixed(char* utf_16_ptr = s) {
			return Encoding.UTF8.GetBytes(utf_16_ptr + start, length, utf_8_bytes, utf_8_byte_count);
		}
	}
}
