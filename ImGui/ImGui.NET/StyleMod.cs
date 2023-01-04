﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace ImGuiNET;

public struct ImGuiStyleMod {
	public ImGuiStyleVar VarIdx;
	public StyleModUnionValue Value;
}

public unsafe struct ImGuiStyleModPtr {
	public ImGuiStyleMod* NativePtr { get; }
	public ImGuiStyleModPtr(ImGuiStyleMod* native_ptr) => NativePtr = native_ptr;
	public ImGuiStyleModPtr(IntPtr native_ptr) => NativePtr = (ImGuiStyleMod*)native_ptr;
	public static implicit operator ImGuiStyleModPtr(ImGuiStyleMod* native_ptr) => new(native_ptr);
	public static implicit operator ImGuiStyleMod*(ImGuiStyleModPtr wrapped_ptr) => wrapped_ptr.NativePtr;
	public static implicit operator ImGuiStyleModPtr(IntPtr native_ptr) => new(native_ptr);
	public ref ImGuiStyleVar VarIdx => ref Unsafe.AsRef<ImGuiStyleVar>(&NativePtr->VarIdx);

	public void Destroy() => ImGuiNative.ImGuiStyleMod_destroy(NativePtr);
}

[StructLayout(LayoutKind.Explicit)]
public struct StyleModUnionValue {
	[FieldOffset(0)]
	public int BackupI32;
	[FieldOffset(0)]
	public float BackupF32;
}
