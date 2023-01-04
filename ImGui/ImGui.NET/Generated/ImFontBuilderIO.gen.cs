using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET;

public unsafe partial struct ImFontBuilderIO {
	public IntPtr FontBuilder_Build;
}
public unsafe partial struct ImFontBuilderIOPtr {
	public ImFontBuilderIO* NativePtr { get; }
	public ImFontBuilderIOPtr(ImFontBuilderIO* nativePtr) => NativePtr = nativePtr;
	public ImFontBuilderIOPtr(IntPtr nativePtr) => NativePtr = (ImFontBuilderIO*)nativePtr;
	public static implicit operator ImFontBuilderIOPtr(ImFontBuilderIO* nativePtr) => new(nativePtr);
	public static implicit operator ImFontBuilderIO*(ImFontBuilderIOPtr wrappedPtr) => wrappedPtr.NativePtr;
	public static implicit operator ImFontBuilderIOPtr(IntPtr nativePtr) => new(nativePtr);
	public ref IntPtr FontBuilder_Build => ref Unsafe.AsRef<IntPtr>(&NativePtr->FontBuilder_Build);
}
