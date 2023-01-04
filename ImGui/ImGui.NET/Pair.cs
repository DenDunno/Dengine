using System;
using System.Runtime.InteropServices;

namespace ImGuiNET;

public struct ImGuiStoragePair {
	public uint Key;
	public PairUnionValue Value;
}

public unsafe struct ImGuiStoragePairPtr {
	public ImGuiStoragePair* NativePtr { get; }
	public ImGuiStoragePairPtr(ImGuiStoragePair* native_ptr) => NativePtr = native_ptr;
	public ImGuiStoragePairPtr(IntPtr native_ptr) => NativePtr = (ImGuiStoragePair*)native_ptr;
	public static implicit operator ImGuiStoragePairPtr(ImGuiStoragePair* native_ptr) => new(native_ptr);
	public static implicit operator ImGuiStoragePair*(ImGuiStoragePairPtr wrapped_ptr) => wrapped_ptr.NativePtr;
	public static implicit operator ImGuiStoragePairPtr(IntPtr native_ptr) => new(native_ptr);
}

[StructLayout(LayoutKind.Explicit)]
public struct PairUnionValue {
	[FieldOffset(0)]
	public int ValueI32;
	[FieldOffset(0)]
	public float ValueF32;
	[FieldOffset(0)]
	public IntPtr ValuePtr;
}
